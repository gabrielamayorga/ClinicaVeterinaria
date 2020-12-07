using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Dados;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaVeterinaria.Controllers
{
    [Authorize]
    public class BanhoTosaController : Controller
    {
        BanhoTosaRepositorio banhotosaRepo;
        ResponsavelRepositorio responsavelRepo;
        BichinhoRepositorio bichinhoRepo;

        public BanhoTosaController(BanhoTosaRepositorio banhotosaRepo, ResponsavelRepositorio responsavelRepo, BichinhoRepositorio bichinhoRepo)
        {
            this.banhotosaRepo = banhotosaRepo;
            this.responsavelRepo = responsavelRepo;
            this.bichinhoRepo = bichinhoRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastroBanhoTosa()
        {
            ViewBag.Title = "Cadastrar Banho e Tosa";
            ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult CadastroBanhoTosa(BanhoTosa banhoTosa)
        {
            var indisponivel = banhotosaRepo.DataIndisponivel(banhoTosa.Data, 0);
            if (indisponivel || banhoTosa.Data.Hour < 8 || banhoTosa.Data.Hour > 18)
            {
                ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
                ModelState.AddModelError("Data", "Horário indisponivel. Das 8h-18h com 15 minutos de intervalo entre banhos e tosas.");
                return View(banhoTosa);
            }

            banhotosaRepo.Adicionar(banhoTosa);

            return RedirectToAction("ListaBanhoTosa");
        }

    [HttpGet]
        public IActionResult ListaBanhoTosa()
        {
            var lista = banhotosaRepo.ListaBanhoTosa();

            return View(lista);
        }
        public IActionResult Remover(int id)
        {
            banhotosaRepo.Remover(id);
            return RedirectToAction("Index", "BanhoTosa");
        }

        [HttpGet]
        public IActionResult AlterarBanhoTosa(int id)
        {
            ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
            return View(banhotosaRepo.ObterBanhoTosaPorId(id));
        }

        [HttpPost]
        public IActionResult AlterarBanhoTosa(BanhoTosa banho)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
                return View(banho);
            }

            var indisponivel = banhotosaRepo.DataIndisponivel(banho.Data, banho.Id);

            if (indisponivel || banho.Data.Hour < 8 || banho.Data.Hour > 18)
            {
                ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
                ModelState.AddModelError("Data", "Horário indisponivel. Das 8h-18h com 15 minutos de intervalo entre banhos e tosas.");
                return View(banho);
            }

            var bt = banhotosaRepo.ObterBanhoTosaPorId(banho.Id);

            bt.BichinhoId = banho.BichinhoId;
            bt.Data = banho.Data;

            banhotosaRepo.Alterar(bt);

            return RedirectToAction("ListaBanhoTosa");
        }
    }
}