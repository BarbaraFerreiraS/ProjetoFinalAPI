using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Service.Dto
{
    public class EventReservationDto
    {
        [Required(ErrorMessage = "Id do evento é um item obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, informe um valor válido!")]
        public int IdEvent { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage ="Nome é um item obrigatório!")]
        [MaxLength(100)]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "A quantidade de reservas é um item obrigatório!")]
        [Range(1,10,ErrorMessage = "A quantidade deve estar entre 1 e 10 unidades!")]
        public int Quantity { get; set; }
    }
}
