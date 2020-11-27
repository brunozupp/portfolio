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
    public class AcademicTrainingController : Controller
    {
        private readonly AcademicTrainingService service;

        public AcademicTrainingController(AcademicTrainingService academicTrainingService)
        {
            service = academicTrainingService;
        }

        public IActionResult Index()
        {

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
                    return RedirectToAction("Details", new { id = academicTraining.ID });
                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao atualizar o registro");
                    return View(academicTraining);
                }

            }
            else
            {
                ResponseAPI<int> responseAPI = await service.Post(academicTraining);

                if (responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    return RedirectToAction("Details", new { id = responseAPI.Content });

                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao cadastrar o registro");
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
