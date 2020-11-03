using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjeto.Repositories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeto.Controllers
{
    [Route("api/details")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly DetailRepository _repository;

        public DetailController(DetailRepository repository)
        {
            _repository = repository;
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
        public async Task<IActionResult> Create([FromBody] Detail detail)
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
        public async Task<IActionResult> Update([FromBody] Detail detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
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

                return Ok(portfolio);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
