using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SiteProjeto.Models;
using SiteProjeto.Models.Services;

namespace SiteProjeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DetailService service;

        private readonly string pathMidia;

        public HomeController(ILogger<HomeController> logger, DetailService detailService, IConfiguration configuration)
        {
            _logger = logger;
            service = detailService;
            pathMidia = configuration.GetSection("pathMidia").Value;
        }

        public IActionResult Index()
        {
            ResponseAPI<DetailsDTO> responseAPI = service.GetPortfolio();

            if (responseAPI.StatusCode == (int)HttpStatusCode.BadRequest) return View();

            ViewBag.PathMidia = pathMidia;

            return View(responseAPI.Content);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
