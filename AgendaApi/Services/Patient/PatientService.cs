using System.Collections.Generic;
using System.Linq;
using AgendaApi.Model.Page;
using AgendaApi.Model.Patient;
using AgendaApi.Repositories.Patient;
using AutoMapper;

namespace AgendaApi.Services.Patient
{
    public class PatientService: IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public Page<PatientDto> GetPage(int page, int limit)
        {
            var count = _patientRepository.Count();
            var patients = _patientRepository
                .GetPage(page, limit)
                .Select(p => _mapper.Map<PatientDto>(p))
                .ToList();
            var meta = new PageMetadata(page, limit, count);
            return new Page<PatientDto>
            {
                Data = patients,
                Meta = meta
            };
        }

        public List<PatientDto> GetAll()
        {
            return _patientRepository
                .FindAll()
                .Select(p => _mapper.Map<PatientDto>(p))
                .ToList();
        }

        public PatientDto GetById(int id)
        {
            var patient = _patientRepository.GetById(id);
            return _mapper.Map<PatientDto>(patient);
        }

        public Model.Patient.Patient Create(PatientCreateDto patientCreateDto)
        {
            return _patientRepository.Add(_mapper.Map<Model.Patient.Patient>(patientCreateDto));
        }

        public bool Update(PatientUpdateDto patientUpdateDto)
        {
            return _patientRepository.Update(_mapper.Map<Model.Patient.Patient>(patientUpdateDto));
        }

        public bool Delete(Model.Patient.Patient patient)
        {
            return _patientRepository.Delete(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }
    }
}