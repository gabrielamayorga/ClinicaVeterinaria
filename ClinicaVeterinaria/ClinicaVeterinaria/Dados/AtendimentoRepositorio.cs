using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Dados
{
    public class AtendimentoRepositorio
    {
        VeterinariaContext _context;

        public AtendimentoRepositorio(VeterinariaContext context)
        {
            _context = context;
        }

        public Atendimento ObterAtendimentoPorId(int id)
        {
            return _context.Atendimentos.FirstOrDefault(a => a.Id == id);
        }

        public void Adicionar(Atendimento atendimento)
        {            
            _context.Atendimentos.Add(atendimento);
            _context.SaveChanges();
        }

        public void Alterar(Atendimento atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            _context.SaveChanges();
        }

        public List<Atendimento> ListaAtendimentos()
        {
            return _context.Atendimentos.Include(b => b.Bichinho).Include(v => v.Veterinario).ToList();
        }

        public void Remover(int id)
        {
            _context.Atendimentos.Remove(ObterAtendimentoPorId(id));
            _context.SaveChanges();
        }

        internal bool DataIndisponivel(DateTime data, int id)
        {
            return _context.Atendimentos.Where(a =>
            id != a.Id && (
            data == a.Data ||
            (data > a.Data && data < a.Data.AddMinutes(15)) ||
            (data.AddMinutes(15) > a.Data && data.AddMinutes(15) < a.Data.AddMinutes(15))))
            .Any();
        }

        //public Bichinho BuscarPorNome(string nome) =>
        //   _context.Bichinhos.FirstOrDefault(x => x.Nome == nome);
    }
}
