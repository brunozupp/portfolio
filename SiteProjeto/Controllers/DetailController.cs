using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Models;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SiteProjeto.Models;
using SiteProjeto.Models.Services;

namespace SiteProjeto.Controllers
{
    public class DetailController : Controller
    {
        private readonly DetailService _service;
        private readonly IMapper _mapper;

        public DetailController(DetailService detailService, IMapper mapper)
        {
            _service = detailService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ResponseAPI<Detail> responseAPI = await _service.Get();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("title", "Erro ao tentar acessar o serviço");
                return View();
            }

            return View(responseAPI.Content);
        }

        public async Task<IActionResult> Save()
        {
            ResponseAPI<Detail> responseAPI = await _service.Get();

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

            DetailViewModel detailViewModel = _mapper.Map<DetailViewModel>(responseAPI.Content);

            return View(detailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DetailViewModel detailViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "As validações não foram atendidas");
                return View(detailViewModel);
            }

            if (detailViewModel.ID > 0)
            {
                ResponseAPI<object> responseAPI = await _service.Put(detailViewModel);

                if (responseAPI.StatusCode == (int)HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "Erro ao atualizar o registro");
                    return View(detailViewModel);
                }

            }
            else
            {
                ResponseAPI<int> responseAPI = await _service.Post(detailViewModel);

                if (responseAPI.StatusCode == (int)HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("title", "Erro ao cadastrar o registro");
                    return View(detailViewModel);
                }
            }
        }
    }
}
