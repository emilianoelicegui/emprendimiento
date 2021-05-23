using Shared.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SaveSaleRequest
    {
        public int IdClient { get; set; }
        public int IdCompany { get; set; }

        [Range(1, 9999999999999999.99, ErrorMessage = "Debe ingresar un 'Monto' válido.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "'Forma de pago' es obligatorio.")]
        public MethodPayment MethodPayment { get; set; }

        [MinLength(1, ErrorMessage = "Debe seleccionar al menos un item.")]
        public List<ItemSaleDto> ItemSales { get; set; }
    }
}
