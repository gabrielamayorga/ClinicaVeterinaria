using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Dados
{
    public class ResponsavelRepositorio
    {
        VeterinariaContext _context;

        public ResponsavelRepositorio(VeterinariaContext context)
        {
            _context = context;
        }

        public Responsavel ObterResponsavelPorId(int id)
        {
            return _context.Responsaveis.FirstOrDefault(r => r.Id == id);
        }

        public void Adicionar(Responsavel responsavel)
        {
            _context.Responsaveis.Add(responsavel);
            _context.SaveChanges();
        }

        public void AlterarResponsavel(Responsavel responsavel)
        {
            _context.Responsaveis.Update(responsavel);
            _context.SaveChanges();
        }

        public List<Responsavel> ListaResponsavel()
        {
            return _context.Responsaveis.ToList();
        }

        public void Remover(int id)
        {
            _context.Responsaveis.Remove(ObterResponsavelPorId(id));
            _context.SaveChanges();
        }

        public Responsavel BuscarPorNome(string nome) =>
           _context.Responsaveis.FirstOrDefault(x => x.Nome == nome);
    }
}
