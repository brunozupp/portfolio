using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [TempData]
        public string Notification { get; set; }

        public IActionResult Index()
        {
            if (!String.IsNullOrWhiteSpace(Notification))
            {
                ViewBag.notification = JsonConvert.DeserializeObject<Notification>(Notification);
            }

            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Project>> responseAPI = await service.GetAll();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return Json(new { error = true });
            }

            return Json(new { error = false, data = responseAPI.Content });
        }

        public async Task<IActionResult> Details(int id)
        {
            ResponseAPI<Project> responseAPI = await service.Get(id);

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

        public async Task<IActionResult> Save(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                ResponseAPI<Project> responseAPI = await service.Get(id);

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
        public async Task<IActionResult> Save(Project project)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("title", "As validações não foram atendidas");
                return View(project);
            }

            if (project.ID > 0)
            {
                ResponseAPI<object> responseAPI = await service.Put(project);

                if (responseAPI.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    Notification = JsonConvert.SerializeObject(new Notification
                    {
                        type = "success",
                        content = "Sucesso ao atualizar o registro"
                    });

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao atualizar o registro");

                    Notification = JsonConvert.SerializeObject(new Notification
                    {
                        type = "success",
                        content = "Erro ao atualizar o registro"
                    });

                    return View(project);
                }

            }
            else
            {
                ResponseAPI<int> responseAPI = await service.Post(project);

                if (responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    Notification = JsonConvert.SerializeObject(new Notification
                    {
                        type = "success",
                        content = "Sucesso ao cadastrar o registro"
                    });

                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao cadastrar o registro");

                    Notification = JsonConvert.SerializeObject(new Notification
                    {
                        type = "error",
                        content = "Erro ao cadastrar o registro"
                    });

                    return View(project);
                }
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseAPI<object> responseAPI = await service.Delete(id);

            if (responseAPI.StatusCode != (int)HttpStatusCode.NoContent)
                return Json(new { error = true });

            return Json(new { error = false });
        }
    }
}
