using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Responsavel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Endereco { get; set; }

        public string Email { get; set; }
    }
}
