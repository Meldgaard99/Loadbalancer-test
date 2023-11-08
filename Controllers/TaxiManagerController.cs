using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using TaxiManagerAPI.Models;




namespace TaxiManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxiManagerController : ControllerBase
    {
        private readonly ILogger<TaxiManagerController> _logger;

        public TaxiManagerController(ILogger<TaxiManagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("version")]
        public async Task<Dictionary<string, string>> GetVersion()
        {
            var properties = new Dictionary<string, string>();
            var assembly = typeof(Program).Assembly;
            properties.Add("service", "TaxiManager");
            var ver = FileVersionInfo.GetVersionInfo(
            typeof(Program).Assembly.Location).ProductVersion ?? "N/A";
            properties.Add("version", ver);
            var hostName = System.Net.Dns.GetHostName();
            var ips = await System.Net.Dns.GetHostAddressesAsync(hostName);
            var ipa = ips.First().MapToIPv4().ToString() ?? "N/A";
            properties.Add("ip-address", ipa);
            return properties;
        }



       [HttpGet("cars")]
public IEnumerable<Car> GetCars()
{
    var cars = new List<Car>
    {
        new Car
        {
            Make = "Toyota",
            Model = "Corolla",
            Year = 2018,
            Color = "Red",
            Mileage = 50000
        }

    };

    return cars;
}
    }

}