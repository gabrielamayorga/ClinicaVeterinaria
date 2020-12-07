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
    public class AtendimentosController : Controller
    {
        AtendimentoRepositorio atendimentoRepo;
        ResponsavelRepositorio responsavelRepo;
        BichinhoRepositorio bichinhoRepo;
        VeterinarioRepositorio veterinarioRepo;

        public AtendimentosController(AtendimentoRepositorio atendimentoRepo, ResponsavelRepositorio responsavelRepo, 
            BichinhoRepositorio bichinhoRepo, VeterinarioRepositorio veterinarioRepo)
        {
            this.atendimentoRepo = atendimentoRepo;
            this.responsavelRepo= responsavelRepo;
            this.bichinhoRepo = bichinhoRepo;
            this.veterinarioRepo = veterinarioRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = atendimentoRepo.ListaAtendimentos();
            return Ok(lista);
        }

        [HttpGet]
        public IActionResult CadastroAtendimento()
        {
            ViewBag.Title = "Cadastrar Atendimento";
            ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
            ViewBag.Veterinarios = new SelectList(veterinarioRepo.ListaVeterinarios(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult CadastroAtendimento(Atendimento atendimento)
        {
            var indisponivel = atendimentoRepo.DataIndisponivel(atendimento.Data, 0);
            if (indisponivel || atendimento.Data.Hour < 8 || atendimento.Data.Hour > 18)
            {
                ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
                ViewBag.Veterinarios = new SelectList(veterinarioRepo.ListaVeterinarios(), "Id", "Nome");
                ModelState.AddModelError("Data", "Horário indisponivel. Das 8h-18h com 15 minutos de intervalo entre atendimentos.");
                return View(atendimento);
            }
            
            atendimentoRepo.Adicionar(atendimento);

            return RedirectToAction("ListaAtendimentos");
        }

        [HttpGet]
        public IActionResult ListaAtendimentos()
        {
            var lista = atendimentoRepo.ListaAtendimentos();

            return View(lista);
        }
        public IActionResult Remover(int id)
        {
            atendimentoRepo.Remover(id);
            return RedirectToAction("ListaAtendimentos");
        }

        //public IActionResult AlterarAtendimento(int id)
        //{
        //    var b = atendimentoRepo.ObterAtendimentoPorId(id);

        //    return View(b);
        //}
        [HttpGet]
        public IActionResult AlterarAtendimento(int id)
        {
            ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
            ViewBag.Veterinarios = new SelectList(veterinarioRepo.ListaVeterinarios(), "Id", "Nome");
            return View(atendimentoRepo.ObterAtendimentoPorId(id));
        }

        [HttpPost]
        public IActionResult AlterarAtendimento(Atendimento atendimento)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
                ViewBag.Veterinarios = new SelectList(veterinarioRepo.ListaVeterinarios(), "Id", "Nome");
                return View(atendimento);
            }
            
            var indisponivel = atendimentoRepo.DataIndisponivel(atendimento.Data, atendimento.Id);

            if (indisponivel || atendimento.Data.Hour < 8 || atendimento.Data.Hour > 18)
            {
                ViewBag.Bichinhos = new SelectList(bichinhoRepo.ListaBichinhos(), "Id", "Nome");
                ViewBag.Veterinarios = new SelectList(veterinarioRepo.ListaVeterinarios(), "Id", "Nome");
                ModelState.AddModelError("Data", "Horário indisponivel. Das 8h-18h com 15 minutos de intervalo entre atendimentos.");
                return View(atendimento);
            }

            var atend = atendimentoRepo.ObterAtendimentoPorId(atendimento.Id);

            atend.BichinhoId = atendimento.BichinhoId;            
            atend.VeterinarioId = atendimento.VeterinarioId;
            atend.Data = atendimento.Data;
            atend.Observacao = atendimento.Observacao;

            atendimentoRepo.Alterar(atend);

            return RedirectToAction("ListaAtendimentos");
        }
    }
}