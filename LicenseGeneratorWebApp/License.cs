using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseGeneratorWebApp
{
    public class License
    {

        [Key]
        public Guid IdLicense { get; set; }

        public string LicenseContent { get; set; } = String.Empty;

        public string LicenseType { get; set; } = String.Empty;

        public string ExpirationDate { get; set; } = String.Empty;

        public Guid IdProdus { get; set; }

        [ForeignKey(nameof(IdProdus))]

        public virtual ProductList ProductList { get; set; }

        public Guid IdClient { get; set; }

        [ForeignKey(nameof(IdClient))]

        public virtual Client Client { get; set; }
    }
}
