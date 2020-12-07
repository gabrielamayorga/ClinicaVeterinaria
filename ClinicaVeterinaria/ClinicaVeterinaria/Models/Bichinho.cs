using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ClinicaVeterinaria.Models
{
    public class Bichinho
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public int? ResponsavelId { get; set; }
        public Responsavel Responsavel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Especie { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Tipo { get; set; }
        public bool Adocao { get; set; }
    }
}
