using System.Collections.Generic;
using System.Linq;
using AgendaApi.Model.Consultation;
using AgendaApi.Model.Page;
using AgendaApi.Repositories.Consultation;
using AutoMapper;

namespace AgendaApi.Services.Consultation
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;
        private readonly IMapper _mapper;

        public ConsultationService(IConsultationRepository consultationRepository, IMapper mapper)
        {
            _consultationRepository = consultationRepository;
            _mapper = mapper;
        }

        public Page<ConsultationDto> GetPage(int page, int limit)
        {
            var count = _consultationRepository.Count();
            var consultations = _consultationRepository.GetPage(page, limit).Select(c => _mapper.Map<ConsultationDto>(c)).ToList();
            var meta = new PageMetadata(page, limit, count);
            return new Page<ConsultationDto>
            {
                Data = consultations,
                Meta = meta
            };
        }

        public List<ConsultationDto> GetAll()
        {
            return _consultationRepository.FindAll().Select(c => _mapper.Map<ConsultationDto>(c)).ToList();
        }

        public ConsultationDto GetById(int id)
        {
            var consultation = _consultationRepository.GetById(id);
            return _mapper.Map<ConsultationDto>(consultation);
        }

        public Model.Consultation.Consultation Create(ConsultationCreateDto consultationCreateDto)
        {
            var consultation = _mapper.Map<Model.Consultation.Consultation>(consultationCreateDto);
            var result = _consultationRepository.Add(consultation);
            return result;
        }

        public bool Update(ConsultationUpdateDto consultationUpdateDto)
        {
            var consultation = _mapper.Map<Model.Consultation.Consultation>(consultationUpdateDto);
            var result = _consultationRepository.Update(consultation);
            return result;
        }

        public bool Delete(Model.Consultation.Consultation consultation)
        {
            return _consultationRepository.Delete(consultation);
        }

        public bool Delete(int id)
        {
            return _consultationRepository.Delete(id);
        }
    }
}