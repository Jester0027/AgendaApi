using System.Collections.Generic;
using AgendaApi.Model.Page;
using AgendaApi.Model.Patient;

namespace AgendaApi.Services.Patient
{
    public interface IPatientService
    {
        Page<PatientDto> GetPage(int page, int limit);
        List<PatientDto> GetAll();
        PatientDto GetById(int id);
        Model.Patient.Patient Create(PatientCreateDto patientCreateDto);
        bool Update(PatientUpdateDto patientUpdateDto);
        bool Delete(Model.Patient.Patient patient);
        bool Delete(int id);
    }
}