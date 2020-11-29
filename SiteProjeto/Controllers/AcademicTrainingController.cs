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
    public class AcademicTrainingController : Controller
    {
        private readonly AcademicTrainingService service;

        public AcademicTrainingController(AcademicTrainingService academicTrainingService)
        {
            service = academicTrainingService;
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
            ResponseAPI<List<AcademicTraining>> responseAPI = await service.GetAll();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return Json(new { error = true });
            }

            return Json(new { error = false, data = responseAPI.Content });
        }

        public async Task<IActionResult> Details(int id)
        {
            ResponseAPI<AcademicTraining> responseAPI = await service.Get(id);

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

        public async Task<IActionResult> Save(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                ResponseAPI<AcademicTraining> responseAPI = await service.Get(id);

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
        public async Task<IActionResult> Save(AcademicTraining academicTraining)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("title", "As validações não foram atendidas");
                return View(academicTraining);
            }

            if (academicTraining.ID > 0)
            {
                ResponseAPI<object> responseAPI = await service.Put(academicTraining);

                if (responseAPI.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    Notification = JsonConvert.SerializeObject(new Notification
                    {
                        type = "success",
                        content = "Sucesso ao atualizar o registro"
                    });

                    //return RedirectToAction("Details", new { id = academicTraining.ID });
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao atualizar o registro");

                    Notification = JsonConvert.SerializeObject(new Notification
                    {
                        type = "error",
                        content = "Erro ao atualizar o registro"
                    });

                    return View(academicTraining);
                }

            }
            else
            {
                ResponseAPI<int> responseAPI = await service.Post(academicTraining);

                if (responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    var notification = JsonConvert.SerializeObject(new Notification
                    {
                        type = "success",
                        content = "Sucesso ao cadastrar o registro"
                    });

                    Notification = notification;

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

                    return View(academicTraining);
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
