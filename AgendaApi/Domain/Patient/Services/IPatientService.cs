using System.Collections.Generic;
using AgendaApi.Domain.Patient.Models;
using AgendaApi.Models.Page;

namespace AgendaApi.Domain.Patient.Services
{
    public interface IPatientService
    {
        Page<PatientDto> GetPage(int page, int limit);
        List<PatientDto> GetAll();
        PatientDto GetById(int id);
        Domain.Patient.Models.Patient Create(PatientCreateDto patientCreateDto);
        bool Update(PatientUpdateDto patientUpdateDto);
        bool Delete(Domain.Patient.Models.Patient patient);
        bool Delete(int id);
    }
}