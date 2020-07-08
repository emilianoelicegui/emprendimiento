using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dto.Layer
{
    public class SaveProviderRequest
    {
        public int Id { get; set; }
        
        [StringLength(20, ErrorMessage = "'Nombre' debe tener entre {2} y {1} caracteres.", MinimumLength = 6)]
        public string Name { get; set; }

        [Range(10000000000, 99999999999, ErrorMessage = "Debe ingresar un 'Cuit/Cuil' válido.")]
        public long Cuit { get; set; }
        public string Email { get; set; }
        public int CodePostal { get; set; }
        public string Floor { get; set; }
        public string Telephone { get; set; }
        public string Department { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public int IdUser { get; set; }
    }
}
