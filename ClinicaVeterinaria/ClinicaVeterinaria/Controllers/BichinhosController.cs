using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Dados;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaVeterinaria.Controllers
{
    [Authorize]
    public class BichinhosController : Controller
    {
        BichinhoRepositorio bichinhoRepo;
        ResponsavelRepositorio responsavelRepo;

        public BichinhosController(BichinhoRepositorio bichinhoRepo, ResponsavelRepositorio responsavelRepo)
        {
            this.bichinhoRepo = bichinhoRepo;
            this.responsavelRepo = responsavelRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = bichinhoRepo.ListaBichinhos();
            return Ok(lista);
        }

        [HttpGet]
        public IActionResult CadastroBichinho()
        {
            ViewBag.Title = "Cadastrar Bichinho";
            ViewBag.Responsaveis = new SelectList(responsavelRepo.ListaResponsavel(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult CadastroBichinho(Bichinho bichinho)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Responsaveis = new SelectList(responsavelRepo.ListaResponsavel(), "Id", "Nome");
                return View(bichinho);
            }

            bichinhoRepo.Adicionar(bichinho);
            
            return RedirectToAction("ListaBichinhos");
        }

        [HttpGet]
        public IActionResult ListaBichinhos()
        {
            var lista = bichinhoRepo.ListaBichinhos();

            return View(lista);
        }

        [HttpGet]
        public IActionResult ListaAdocao()
        {
            var lista = bichinhoRepo.ListaAdocao();

            return View(lista);
        }

        public IActionResult Remover(int id)
        {
            bichinhoRepo.Remover(id);
            return RedirectToAction("ListaBichinhos");
        }

        [HttpGet]
        public IActionResult AlterarBichinho(int id)
        {
            ViewBag.Responsaveis = new SelectList(responsavelRepo.ListaResponsavel(), "Id", "Nome");
            return View(bichinhoRepo.ObterBichinhoPorId(id));
        }

        [HttpPost]
        public IActionResult AlterarBichinho(Bichinho dadosDaTela)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Responsaveis = new SelectList(responsavelRepo.ListaResponsavel(), "Id", "Nome");
                return View(dadosDaTela);
            }
            var dadosDoBanco = bichinhoRepo.ObterBichinhoPorId(dadosDaTela.Id);

            dadosDoBanco.Nome = dadosDaTela.Nome;
            dadosDoBanco.Especie = dadosDaTela.Especie;
            dadosDoBanco.ResponsavelId = dadosDaTela.ResponsavelId;
            dadosDoBanco.Tipo= dadosDaTela.Tipo;
            dadosDoBanco.DataNascimento = dadosDaTela.DataNascimento;
            dadosDoBanco.Adocao = dadosDaTela.Adocao;

            bichinhoRepo.AlterarBichinho(dadosDoBanco);

            return RedirectToAction("ListaBichinhos");
        }
    }
}