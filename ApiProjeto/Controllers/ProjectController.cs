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
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepositoryBase<Project> _repository;

        public ProjectController(ProjectRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var projects = (await _repository.GetAll()).ToList();

                return Ok(projects);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var project = await _repository.Get(id);

                if (project == null) return NotFound();

                return Ok(project);
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
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _repository.Insert(project);

                    if(result > 0)
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
        public async Task<IActionResult> Update([FromBody] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _repository.Update(project);

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

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);

                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
