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
    public class VeterinariosController : Controller
    {
        VeterinarioRepositorio veterinarioRepo;

        public VeterinariosController(VeterinarioRepositorio veterinarioRepo)
        {
            this.veterinarioRepo = veterinarioRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastroVeterinario()
        {
            ViewBag.Title = "Cadastrar Veterinario";
            ViewBag.Categorias = new SelectList(veterinarioRepo.ListaVeterinarios(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult CadastroVeterinario(Veterinario veterinario)
        {
            if (!ModelState.IsValid)
            {
                return View(veterinario);
            }

            veterinarioRepo.Adicionar(veterinario);

            return RedirectToAction("ListaVeterinarios");
        }

        [HttpGet]
        public IActionResult ListaVeterinarios()
        {
            var lista = veterinarioRepo.ListaVeterinarios();

            return View(lista);
        }
        public IActionResult Remover(int id)
        {
            veterinarioRepo.Remover(id);
            return RedirectToAction("Index", "Veterinario");
        }

        [HttpGet]
        public IActionResult AlterarVeterinario(int id)
        {
            ViewBag.Veterinarios = new SelectList(veterinarioRepo.ListaVeterinarios(), "Id", "Nome");
            return View(veterinarioRepo.ObterVeterinarioPorId(id));
        }

        [HttpPost]
        public IActionResult AlterarVeterinario(Veterinario veterinario)
        {
            if (!ModelState.IsValid)
            {
                return View(veterinario);
            }

            var vet = veterinarioRepo.ObterVeterinarioPorId(veterinario.Id);

            vet.Nome = veterinario.Nome;
            vet.CPF = veterinario.CPF;
            vet.CRMV = veterinario.CRMV;
           

            veterinarioRepo.AlterarVeterinario(vet);

            return RedirectToAction("ListaVeterinarios");
        }

    }
}