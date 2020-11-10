using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiProjeto.Repositories;
using ImageHelper;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiProjeto.Controllers
{
    [Route("api/details")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly DetailRepository _repository;
        private readonly ImageService _imageService;
        private readonly IConfiguration _configuration;

        public DetailController(IConfiguration configuration, DetailRepository repository, ImageService imageService)
        {
            _configuration = configuration;
            _repository = repository;
            _imageService = imageService;
        }

        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {   
                // Pegando o primeiro detalhe, por padrão, vai ter apenas um cadastrado
                var detail = (await _repository.GetAll()).ToList().FirstOrDefault();

                if (detail == null)
                {
                    return NotFound();
                }

                if (!String.IsNullOrWhiteSpace(detail.Photo))
                    detail.Photo = Path.Combine(_configuration.GetSection("rootPath").Value, detail.Photo);

                return Ok(detail);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] Detail detail)
        {
            try
            {

                if((await _repository.GetAll()).Count() == 1)
                {
                    ModelState.AddModelError("title", "Usuário já foi inserido no banco");

                    return BadRequest(ModelState);
                }

                if (ModelState.IsValid)
                {
                    if(Request.Form.Files != null && Request.Form.Files.Count > 0)
                    {
                        ImageModel image = await _imageService.Save(Request.Form.Files[0], @"Upload\Details");

                        if(image == null)
                        {
                            ModelState.AddModelError("title", "Erro ao fazer upload do arquivo");

                            return BadRequest(ModelState);
                        }

                        detail.Photo = image.PartialPath(@"Upload\Details");
                    }

                    var result = await _repository.Insert(detail);

                    if (result > 0)
                    {
                        return Ok(new { ID = result });
                    }
                }

                ModelState.AddModelError("title", "Um ou mais erros ocorreram no cadastro");

                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] Detail detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Form.Files != null && Request.Form.Files.Count > 0)
                    {
                        // Caso não seja a primeira alteração, não terei uma foto
                        if(!String.IsNullOrWhiteSpace(detail.Photo))
                        {
                            var path = Directory.GetCurrentDirectory() +
                            detail.Photo.Substring(detail.Photo.IndexOf(@"/Upload"));

                            _imageService.Delete(path);
                        }

                        ImageModel image = await _imageService.Save(Request.Form.Files[0], @"Upload\Details");

                        if (image == null)
                        {
                            ModelState.AddModelError("title", "Erro ao fazer upload do arquivo");

                            return BadRequest(ModelState);
                        }

                        detail.Photo = image.PartialPath(@"Upload\Details");
                    } else
                    {
                        if(!String.IsNullOrWhiteSpace(detail.Photo))
                            detail.Photo = detail.Photo.Substring(detail.Photo.IndexOf(@"/Upload") + 1);
                    }

                    var result = await _repository.Update(detail);

                    if (result)
                    {
                        return NoContent();
                    }

                    return BadRequest();
                }

                ModelState.AddModelError("title", "Um ou mais erros ocorreram no cadastro");

                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("getPortfolio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPortfolio()
        {
            try
            {
                var portfolio = await _repository.GetPortfolio();

                if(!String.IsNullOrWhiteSpace(portfolio.Detail.Photo))
                    portfolio.Detail.Photo = Path.Combine(_configuration.GetSection("rootPath").Value, portfolio.Detail.Photo);

                return Ok(portfolio);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
