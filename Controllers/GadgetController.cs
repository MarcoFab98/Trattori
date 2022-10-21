using Microsoft.AspNetCore.Mvc;
using Trattori.Model;
using Trattori.Services;

namespace Trattori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GadgetController : ControllerBase
    {
        private readonly IGadgetService _service;

        public GadgetController(IGadgetService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult AddGadget([FromBody]Gadget gadget)
        {
            _service.AddGadget(gadget);

            return Ok();
        }

        [HttpPut("{GadgetId}/{TrattoreId}")]
        public IActionResult InsertGadgetInTrattore(int GadgetId, int TrattoreId)
        {
            var gadgetInTrattore = _service.InsertGadgetInTrattore(GadgetId,TrattoreId);

            return Ok(gadgetInTrattore);
        }
    }
}
