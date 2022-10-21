using Microsoft.AspNetCore.Mvc;
using Trattori.Model.Post;
using Trattori.Services;

namespace Trattori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrattoreController : ControllerBase
    {
        private readonly ITrattoreService _service;

        public TrattoreController(ITrattoreService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var trattoreById = _service.GetDetails(id);
            if (trattoreById == null)
                return NotFound("Trattore not found");
            return Ok(trattoreById);
        }
        
        [HttpGet("{colore}/color")]
        public IActionResult GetByColor(string colore)
        {
            var TrattoriColor = _service.GetByColor(colore);

            return Ok(TrattoriColor);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PostTrattoreModel trattore)
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

        [HttpPut()]
        public IActionResult PutTrattore(int id, [FromBody] PostTrattoreModel trattore)
        {
            _service.Modifica(id, trattore);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _service.Remove(id);
            return Ok();
        }


    }
}
