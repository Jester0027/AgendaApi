using AgendaApi.Domain.Consultation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Domain.Consultation.Controllers
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