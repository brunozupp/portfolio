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
    [Route("api/academictrainings")]
    [ApiController]
    public class AcademicTrainingController : ControllerBase
    {
        private readonly IRepositoryBase<AcademicTraining> _repository;

        public AcademicTrainingController(AcademicTrainingRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var academicTrainings = _repository.GetAll().ToList();

                return Ok(academicTrainings);
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
        public IActionResult Get(int id)
        {
            try
            {
                var academicTraining = _repository.Get(id);

                if (academicTraining == null) return NotFound();

                return Ok(academicTraining);
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
        public IActionResult Create([FromBody] AcademicTraining academicTraining)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _repository.Insert(academicTraining);

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
        public IActionResult Update([FromBody] AcademicTraining academicTraining)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _repository.Update(academicTraining);

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
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);

                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
