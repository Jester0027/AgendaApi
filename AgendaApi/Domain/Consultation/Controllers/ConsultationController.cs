using AgendaApi.Domain.Consultation.Models;
using AgendaApi.Domain.Consultation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AgendaApi.Domain.Consultation.Controllers
{
    [ApiController]
    [Route("api/consultations")]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;
        private readonly ILogger<ConsultationController> _logger;

        public ConsultationController(IConsultationService consultationService, ILogger<ConsultationController> logger)
        {
            _consultationService = consultationService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetConsultations([FromQuery] int? page, [FromQuery] int? limit)
        {
            if (page != null)
            {
                var consultationsPage = _consultationService.GetPage((int) page, limit ?? 10);
                return Ok(consultationsPage);
            }
            var consultations = _consultationService.GetAll();
            return Ok(consultations);
        }

        [HttpGet("{id:int}", Name = "GetConsultation")]
        public IActionResult GetConsultation(int id)
        {
            var consultation = _consultationService.GetById(id);
            if (consultation == null)
            {
                return NotFound();
            }

            return Ok(consultation);
        }
    
        [HttpPost]
        public IActionResult Create([FromBody] ConsultationCreateDto consultationCreateDto)
        {
            var result = _consultationService.Create(consultationCreateDto);
            _logger.LogDebug("Consultation created : {consultation}", JsonConvert.SerializeObject(result));
            return CreatedAtRoute("GetConsultation", new {id = result.Id}, result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ConsultationUpdateDto consultationUpdateDto)
        {
            if (!_consultationService.Update(consultationUpdateDto))
            {
                _logger.LogDebug("An error occured while updating the consultation : {consultation}", JsonConvert.SerializeObject(consultationUpdateDto));
                return BadRequest(ModelState);
            }
            _logger.LogDebug("Consultation updated : {consultation}", JsonConvert.SerializeObject(consultationUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!_consultationService.Delete(id))
            {
                _logger.LogDebug("An error occured while deleting the consultation at id : {id}", id);
            }
            _logger.LogDebug("Consultation at id \"{id}\" deleted", id);
            return NoContent();
        }
    }
}