using System;
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
    public class ProjectController : Controller
    {
        private readonly ProjectService service;

        public ProjectController(ProjectService projectService)
        {
            service = projectService;
        }

        public IActionResult Index()
        {
            ResponseAPI<List<Project>> responseAPI = service.GetAll();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            return View(responseAPI.Content);
        }

        public IActionResult Details(int id)
        {
            ResponseAPI<Project> responseAPI = service.Get(id);

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            if (responseAPI.StatusCode == (int)HttpStatusCode.NotFound)
            {
                ModelState.AddModelError("title", "Projeto não encontrada");
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
                ResponseAPI<Project> responseAPI = service.Get(id);

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
        public IActionResult Save(Project project)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("title", "As validações não foram atendidas");
                return View(project);
            }

            if (project.ID > 0)
            {
                ResponseAPI<object> responseAPI = service.Put(project);

                if (responseAPI.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Details", new { id = project.ID });
                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao atualizar o registro");
                    return View(project);
                }

            }
            else
            {
                ResponseAPI<int> responseAPI = service.Post(project);

                if (responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    return RedirectToAction("Details", new { id = responseAPI.Content });

                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao cadastrar o registro");
                    return View(project);
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
