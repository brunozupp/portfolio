using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SiteProjeto.Models;
using SiteProjeto.Models.Services;

namespace SiteProjeto.Controllers
{
    public class SkillController : Controller
    {
        private readonly SkillService service;

        public SkillController(SkillService skillService)
        {
            service = skillService;
        }

        public IActionResult Index()
        {
            ResponseAPI<List<Skill>> responseAPI = service.GetAll();

            if(responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            return View(responseAPI.Content);
        }

        public IActionResult Details(int id)
        {
            ResponseAPI<Skill> responseAPI = service.Get(id);

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            if (responseAPI.StatusCode == (int)HttpStatusCode.NotFound)
            {
                ModelState.AddModelError("title", "Habilidate não encontrada");
                return View();
            }

            return View(responseAPI.Content);
        }

        public IActionResult Save(int id = 0)
        {
            if(id == 0)
            {
                return View();
            } else
            {
                ResponseAPI<Skill> responseAPI = service.Get(id);

                if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
                {
                    ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                    return View();
                }

                if (responseAPI.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    ModelState.AddModelError("title", "Habilidate não encontrada");
                    return View();
                }

                return View(responseAPI.Content);
            }
        }

        [HttpPost]
        public IActionResult Save(Skill skill)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("title", "As validações não foram atendidas");
                return View(skill);
            }

            if(skill.ID > 0)
            {
                ResponseAPI<object> responseAPI = service.Put(skill);

                if(responseAPI.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Details", new { id = skill.ID });
                } else
                {
                    ModelState.AddModelError("title", "Erro ao atualizar o registro");
                    return View(skill);
                }

            } else
            {
                ResponseAPI<int> responseAPI = service.Post(skill);

                if(responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    return RedirectToAction("Details", new { id = responseAPI.Content });

                } else
                {
                    ModelState.AddModelError("title", "Erro ao cadastrar o registro");
                    return View(skill);
                }
            } 
        }

        public IActionResult Delete(int id)
        {
            ResponseAPI<object> responseAPI = service.Delete(id);

            if (responseAPI.StatusCode != (int)HttpStatusCode.NoContent)
                ModelState.AddModelError("title", "Erro ao deletar o registro");

            return RedirectToAction("Index");
        }
    }
}
