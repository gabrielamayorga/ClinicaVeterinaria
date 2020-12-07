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
    public class ResponsaveisController : Controller
    {
        ResponsavelRepositorio responsavelRepo;

        public ResponsaveisController(ResponsavelRepositorio responsavelRepo)
        {
            this.responsavelRepo = responsavelRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = responsavelRepo.ListaResponsavel();
            return Ok(lista);
        }

        [HttpGet]
        public IActionResult CadastroResponsavel()
        {
            ViewBag.Title = "Cadastrar Responsavel";
            ViewBag.Categorias = new SelectList(responsavelRepo.ListaResponsavel(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult CadastroResponsavel(Responsavel responsavel)
        {
            if (!ModelState.IsValid)
            {
                return View(responsavel);
            }

            responsavelRepo.Adicionar(responsavel);

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = responsavelRepo.ListaResponsavel();

            return View(lista);
        }

        public IActionResult Remover(int id)
        {
            responsavelRepo.Remover(id);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult AlterarResponsavel(int id)
        {
            var b = responsavelRepo.ObterResponsavelPorId(id);

            return View(b);
        }
        [HttpPost]
        public IActionResult AlterarResponsavel(Responsavel a)
        {
            var b = responsavelRepo.ObterResponsavelPorId(a.Id);
            b.Nome = a.Nome;
            b.DataNascimento = a.DataNascimento;
            b.CPF = a.CPF;
            b.Email = a.Email;
            b.Endereco = a.Endereco;

            responsavelRepo.AlterarResponsavel(b);

            return RedirectToAction("Listar");
        }
        
    }
}