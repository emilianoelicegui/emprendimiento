using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dto.Layer
{
    public class GetProductsRequestDto
    {
        public string Name { get; set; }
        public int? IdCompany { get; set; }

        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
