using System.ComponentModel.DataAnnotations;

namespace LicenseGeneratorWebApp
{
    public class ProductList
    {
        [Key]
        public Guid IdProdus { get; set; }
        public string NumeProdus { get; set; } = String.Empty;

        public string ShortCode { get; set; } = String.Empty;

        public string Status { get; set; } = String.Empty;


    }
}
