﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using SiteProjeto.Models;
using SiteProjeto.Models.Services;

namespace SiteProjeto.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ExperienceService service;

        public ExperienceController(ExperienceService experienceService)
        {
            service = experienceService;
        }

        public IActionResult Index()
        {
            ResponseAPI<List<Experience>> responseAPI = service.GetAll();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            return View(responseAPI.Content);
        }

        public IActionResult Details(int id)
        {
            ResponseAPI<Experience> responseAPI = service.Get(id);

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            if (responseAPI.StatusCode == (int)HttpStatusCode.NotFound)
            {
                ModelState.AddModelError("title", "Experiência não encontrada");
                return View();
            }

            return View(responseAPI.Content);
        }

        public IActionResult Save(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                ResponseAPI<Experience> responseAPI = service.Get(id);

                if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
                {
                    ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                    return View();
                }

                if (responseAPI.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    ModelState.AddModelError("title", "Formação não encontrada");
                    return View();
                }

                return View(responseAPI.Content);
            }
        }

        [HttpPost]
        public IActionResult Save(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("title", "As validações não foram atendidas");
                return View(experience);
            }

            if (experience.ID > 0)
            {
                ResponseAPI<object> responseAPI = service.Put(experience);

                if (responseAPI.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Details", new { id = experience.ID });
                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao atualizar o registro");
                    return View(experience);
                }

            }
            else
            {
                ResponseAPI<int> responseAPI = service.Post(experience);

                if (responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    return RedirectToAction("Details", new { id = responseAPI.Content });

                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao cadastrar o registro");
                    return View(experience);
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