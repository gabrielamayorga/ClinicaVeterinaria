using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Dados
{
    public class VeterinarioRepositorio
    {
        VeterinariaContext _context;

        public VeterinarioRepositorio(VeterinariaContext context)
        {
            _context = context;
        }

        public Veterinario ObterVeterinarioPorId(int id)
        {
            return _context.Veterinarios.FirstOrDefault(v => v.Id == id);
        }

        public void Adicionar(Veterinario veterinario)
        {            
            _context.Veterinarios.Add(veterinario);
            _context.SaveChanges();
        }

        public void AlterarVeterinario(Veterinario veterinario)
        {
            _context.Veterinarios.Update(veterinario);
            _context.SaveChanges();
        }
      

        public List<Veterinario> ListaVeterinarios()
        {
            return _context.Veterinarios.ToList();
        }

        public void Remover(int id)
        {
            _context.Veterinarios.Remove(ObterVeterinarioPorId(id));
            _context.SaveChanges();
        }

        public Veterinario BuscarPorNome(string nome) =>
           _context.Veterinarios.FirstOrDefault(x => x.Nome == nome);
    }
}
