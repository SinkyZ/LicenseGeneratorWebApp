using LicenseGeneratorWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portable.Licensing;


namespace LicenseGeneratorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {

        private readonly DataContext _context;
        public LicenseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLicenses()
        {
            var licenes = await _context.Licenses.ToListAsync();
            return Ok(licenes);
        }


        [HttpPost]
        public async Task<IActionResult> GenerateLicense(DefaultLicense defaultLicense)
        {

            var passPhrase = "L-493fAAAAAAAAAA";
            var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();
            var keyPair = keyGenerator.GenerateKeyPair();
            var privateKey = keyPair.ToEncryptedPrivateKeyString(passPhrase);
            var publicKey = keyPair.ToPublicKeyString();

            var clientName = "Adi";


            var license = License.New()
                .WithUniqueIdentifier(Guid.NewGuid())
                .As(LicenseType.Standard)
                .ExpiresAt(DateTime.Now.AddDays(30))
                .WithMaximumUtilization(5)
                .WithProductFeatures(new Dictionary<string, string>
                                              {
                                                  {"Sales Module", "yes"},
                                                  {"Purchase Module", "yes"},
                                                  {"Maximum Transactions", "10000"}
                                              })
                .LicensedTo(clientName, "john.doe@yourmail.here")
                .CreateAndSignWithPrivateKey(privateKey, passPhrase);

            defaultLicense.LicenseContent = license.ToString();

            _context.Licenses.Add(defaultLicense);
            await _context.SaveChangesAsync();
            return Ok(await _context.Licenses.ToListAsync());
        }


    }

    
}
