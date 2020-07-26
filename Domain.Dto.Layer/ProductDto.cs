
namespace Domain.Dto.Layer
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDolar { get; set; }
        public int IdCompany { get; set; }
        public CompanyDto Company { get; set; }
    }
}
