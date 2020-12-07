using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Dados
{
    public class BichinhoRepositorio
    {
        VeterinariaContext _context;

        public BichinhoRepositorio(VeterinariaContext context)
        {
            _context = context;
        }

        public Bichinho ObterBichinhoPorId(int id)
        {
            return _context.Bichinhos.FirstOrDefault(b => b.Id == id);
        }

        public void Adicionar(Bichinho bichinho)
        {            
            _context.Bichinhos.Add(bichinho);
            _context.SaveChanges();
        }

        public void AlterarBichinho(Bichinho bichinho)
        {
            _context.Bichinhos.Update(bichinho);
            _context.SaveChanges();
        }

        public List<Bichinho> ListaBichinhos()
        {
          return  _context.Bichinhos.ToList();
        }

        public List<Bichinho> ListaAdocao()
        {
            return _context.Bichinhos.Where(x => x.ResponsavelId == null).ToList();
        }

        public void Remover(int id)
        {
            _context.Bichinhos.Remove(ObterBichinhoPorId(id));
            _context.SaveChanges();
        }

        public Bichinho BuscarPorNome(string nome) =>
           _context.Bichinhos.FirstOrDefault(x => x.Nome == nome);

    }
}
