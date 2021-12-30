using AgendaApi.Model.Consultation;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/consultations")]
    public class ConsultationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] ConsultationCreateDto consultationCreateDto)
        {
            return Ok(consultationCreateDto);
        }
    }
}