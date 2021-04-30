using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.Layer
{
    public class SaveSpendingRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "'Tipo' es requerido.")]
        [Range(1, 99, ErrorMessage = "Debe ingrear un 'Tipo' válido.")]
        public short Type { get; set; }

        [Required(ErrorMessage = "'Monto' es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar un 'Monto' válido.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "'Empresa' es requerido.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar 'empresa' válida.")]
        public int IdCompany { get; set; }
    }
}
