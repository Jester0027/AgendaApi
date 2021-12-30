using AgendaApi.Model.Patient;
using AgendaApi.Services.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult GetPatients([FromQuery] int? page, [FromQuery] int? limit)
        {
            if (page == null)
            {
                var patients = _patientService.GetAll();
                return Ok(patients);
            }

            var patientsPage = _patientService.GetPage((int) page, limit ?? 10);
            return Ok(patientsPage);
        }

        [HttpGet("{id:int}", Name = "GetPatient")]
        public IActionResult GetPatient(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] PatientCreateDto patientCreateDto)
        {
            var patient = _patientService.Create(patientCreateDto);
            _logger.LogDebug("Patient created : {patient}", JsonConvert.SerializeObject(patient));
            return CreatedAtRoute("GetPatient", new {id = patient.Id}, patient);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PatientUpdateDto patientUpdateDto)
        {
            if (!_patientService.Update(patientUpdateDto))
            {
                _logger.LogDebug("An Error occured while updating the patient : {patient}", JsonConvert.SerializeObject(patientUpdateDto));
                return BadRequest(ModelState);
            }
            _logger.LogDebug("Patient updated: {patient}", JsonConvert.SerializeObject(patientUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_patientService.GetById(id) == null)
            {
                _logger.LogDebug("Patient not found at id : {id}", id);
                return NotFound();
            }
            if (!_patientService.Delete(id))
            {
                
                _logger.LogDebug("An Error occured while deleting the patient with the id : {id}", id);
                return BadRequest(ModelState);
            }
            _logger.LogDebug("Patient with id \"{id}\" successfully deleted", id);
            return NoContent();
        }
    }
}