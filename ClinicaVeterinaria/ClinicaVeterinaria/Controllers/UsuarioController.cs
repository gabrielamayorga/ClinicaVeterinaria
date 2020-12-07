using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly VeterinariaContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(VeterinariaContext context,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
                
        public void AdicionarErros(IdentityResult result)
        {
            foreach (IdentityError erro in result.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login usuarioLogado)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogado.Email, usuarioLogado.Senha, false, false);           

            var name = User.Identity.Name;
            if (result.Succeeded)
            {
                return RedirectToAction("ListaAtendimentos", "Atendimentos");
            }


            

            ModelState.AddModelError("Email", "Login ou senha inválidos!");
            return View(usuarioLogado);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}