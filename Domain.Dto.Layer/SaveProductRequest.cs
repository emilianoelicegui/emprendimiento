using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SaveProductRequest
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "'Nombre' debe tener entre {2} y {1} caracteres.", MinimumLength = 6)]
        public string Name { get; set; }
        [StringLength(250, ErrorMessage = "'Descripción' debe tener un máximo de {1} caracteres.")]
        public string Description { get; set; }
        [Range(1, 9999999999999999.99, ErrorMessage = "Debe ingresar un 'Precio' válido.")]
        public decimal Price { get; set; }
        public bool IsDolar { get; set; }
        public int IdCompany { get; set; }
        public bool IsDelete { get; set; }
    }
}
