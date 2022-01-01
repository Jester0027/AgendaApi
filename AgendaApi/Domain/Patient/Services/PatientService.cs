using System.Collections.Generic;
using System.Linq;
using AgendaApi.Domain.Patient.Models;
using AgendaApi.Domain.Patient.Repositories;
using AgendaApi.Models.Page;
using AutoMapper;

namespace AgendaApi.Domain.Patient.Services
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

        public Domain.Patient.Models.Patient Create(PatientCreateDto patientCreateDto)
        {
            return _patientRepository.Add(_mapper.Map<Domain.Patient.Models.Patient>(patientCreateDto));
        }

        public bool Update(PatientUpdateDto patientUpdateDto)
        {
            return _patientRepository.Update(_mapper.Map<Domain.Patient.Models.Patient>(patientUpdateDto));
        }

        public bool Delete(Domain.Patient.Models.Patient patient)
        {
            return _patientRepository.Delete(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }
    }
}