using System.ComponentModel.DataAnnotations;

namespace LicenseGeneratorWebApp
{
    public class Client
    {

        [Key]

        public Guid IdClient { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;


    }
}
