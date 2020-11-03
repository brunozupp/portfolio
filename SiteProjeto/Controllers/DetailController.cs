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
    public class DetailController : Controller
    {
        private readonly DetailService service;

        public DetailController(DetailService detailService)
        {
            service = detailService;
        }

        public async Task<IActionResult> Index()
        {
            ResponseAPI<Detail> responseAPI = await service.Get();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            return View(responseAPI.Content);
        }

        public async Task<IActionResult> Save()
        {
            ResponseAPI<Detail> responseAPI = await service.Get();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return RedirectToAction("Index");
            }

            // O usuário ainda não foi cadastrado
            if (responseAPI.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return View();
            }

            return View(responseAPI.Content);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Detail detail)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("title", "As validações não foram atendidas");
                return View(detail);
            }

            if (detail.ID > 0)
            {
                ResponseAPI<object> responseAPI = await service.Put(detail);

                if (responseAPI.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao atualizar o registro");
                    return View(detail);
                }

            }
            else
            {
                ResponseAPI<int> responseAPI = await service.Post(detail);

                if (responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao cadastrar o registro");
                    return View(detail);
                }
            }
        }
    }
}
