using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StockCheck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockCheckController : ControllerBase
    {
        private readonly ILogger<StockCheckController> _logger;

        public StockCheckController(ILogger<StockCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StockCheck> Get()
        {
            var rng = new Random();
            IEnumerable<StockCheck> update = Enumerable.Range(1, 100).Select(index => new StockCheck
            {
                itemID = rng.Next(1, 5),
                stockLeft = rng.Next(0, 55)
            });
            
            return update;
        }
    }
}
