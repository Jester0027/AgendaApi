using System;
using System.Collections.Generic;
using System.Linq;
using AgendaApi.Domain.Consultation.Models;
using AgendaApi.Domain.Consultation.Repositories;
using AgendaApi.Domain.User.Models;
using AgendaApi.Domain.User.Services;
using AgendaApi.Models.Page;
using AutoMapper;

namespace AgendaApi.Domain.Consultation.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ConsultationService(IConsultationRepository consultationRepository, IMapper mapper, IUserService userService)
        {
            _consultationRepository = consultationRepository;
            _mapper = mapper;
            _userService = userService;
        }

        private void CheckUserIsDoctor(int id)
        {
            var user = _userService.GetById(id);
            if (user.Role != Role.Doctor.ToString())
            {
                throw new Exception("The user id passed is not a doctor id");
            }
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

        public Models.Consultation Create(ConsultationCreateDto consultationCreateDto)
        {
            CheckUserIsDoctor(consultationCreateDto.DoctorId);
            var consultation = _mapper.Map<Models.Consultation>(consultationCreateDto);
            consultation.Status = ConsultationStatus.Pending;
            var result = _consultationRepository.Add(consultation);
            return result;
        }

        public bool Update(ConsultationUpdateDto consultationUpdateDto)
        {
            var consultation = _mapper.Map<Models.Consultation>(consultationUpdateDto);
            var result = _consultationRepository.Update(consultation);
            return result;
        }

        public bool Delete(Models.Consultation consultation)
        {
            return _consultationRepository.Delete(consultation);
        }

        public bool Delete(int id)
        {
            return _consultationRepository.Delete(id);
        }
    }
}