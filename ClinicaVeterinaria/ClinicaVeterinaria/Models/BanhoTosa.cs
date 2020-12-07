using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class BanhoTosa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public int BichinhoId { get; set; }
        public Bichinho Bichinho { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public DateTime Data { get; set; }
    }
}
