
namespace Domain.Dto.Layer
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool IsDolar { get; set; }
        public string Money { get; set; }
        public int IdCompany { get; set; }
        public CompanyDto Company { get; set; }

        public string MoneyToShortString()
        {
            if (IsDolar)
            {
                return "US$";
            }
            else
            {
                return "$";
            }
        }

        public string MoneyToLongString()
        {
            if (IsDolar)
            {
                return "Dólar (US$)";
            }
            else
            {
                return "Peso ($)";
            }
        }
    }
}
