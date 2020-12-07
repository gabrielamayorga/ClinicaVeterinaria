using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Atendimento
    {
        //public Atendimento() => Atendimento = new Atendimento();

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int BichinhoId { get; set; }
                
        public Bichinho Bichinho { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int VeterinarioId { get; set; }

        public Veterinario Veterinario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public DateTime Data { get; set; }

        public string Observacao { get; set; }
    }
}
