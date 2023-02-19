using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Service.Dto
{
    public class CityEventDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O título é um item obrigatório!")]
        [MaxLength(255)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "A data do evento é um item obrigatório!")]
        public DateTime DateHourEvent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A localização é um item obrigatório!")]
        [MaxLength(255)]
        public string Local { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        public Decimal? Price { get; set; }
        public bool Status { get; set; }
    }
}
