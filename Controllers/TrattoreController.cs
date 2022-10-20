using Microsoft.AspNetCore.Mvc;
using Trattori.Model;
using Trattori.Services;

namespace Trattori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrattoreController : Controller
    {
        private readonly ITrattoreService _service;

        public TrattoreController(ITrattoreService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var trattoreById = _service.GetDetails(id);
            if (trattoreById == null)
                return NotFound("Trattore not found");
            return Ok(trattoreById);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Trattore trattore)
        {
            var trattoreAdd = _service.AddTrattore(trattore);
            return CreatedAtAction(
                nameof(GetDetail),
                new
                {
                    id = trattoreAdd.Id
                },
                trattoreAdd);
        }

        [HttpGet("{colore}/color")]
        public IActionResult GetByColor(string colore)
        {
            var TrattoriColor = _service.GetByColor(colore);

            return Ok(TrattoriColor);
        }


    }
}
