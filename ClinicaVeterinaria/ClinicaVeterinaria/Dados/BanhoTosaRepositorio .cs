using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Dados
{
    public class BanhoTosaRepositorio
    {
        VeterinariaContext _context;

        public BanhoTosaRepositorio(VeterinariaContext context)
        {
            _context = context;
        }

        public BanhoTosa ObterBanhoTosaPorId(int id)
        {
            return _context.BanhoTosa.FirstOrDefault(b => b.Id == id);
        }

        public void Adicionar(BanhoTosa banhoTosa)
        {            
            _context.BanhoTosa.Add(banhoTosa);
            _context.SaveChanges();
        }

        public void Alterar(BanhoTosa banhoTosa)
        {
            _context.BanhoTosa.Update(banhoTosa);
            _context.SaveChanges();
        }

        public List<BanhoTosa> ListaBanhoTosa()
        {
            return _context.BanhoTosa.Include(b => b.Bichinho).ToList();
        }

        public void Remover(int id)
        {
            _context.BanhoTosa.Remove(ObterBanhoTosaPorId(id));
            _context.SaveChanges();
        }

        internal bool DataIndisponivel(DateTime data, int id)
        {
            return _context.BanhoTosa.Where(a =>
            a.Id != id && (
            data == a.Data ||
            (data > a.Data && data < a.Data.AddMinutes(15)) ||
            (data.AddMinutes(15) > a.Data && data.AddMinutes(15) < a.Data.AddMinutes(15))))
            .Any();
        }

        //public Bichinho BuscarPorNome(string nome) =>
        //   _context.Bichinhos.FirstOrDefault(x => x.Nome == nome);
    }
}
