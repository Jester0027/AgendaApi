using System;
using System.ComponentModel.DataAnnotations;
using AgendaApi.Validations;

namespace AgendaApi.Model.Consultation
{
    public class ConsultationDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public User.User Doctor { get; set; }
        public Patient.Patient Patient { get; set; }
    }
    
    public class ConsultationCreateDto
    {
        [Required]
        [ValidConsultationDate]
        public DateTime Date { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
    
    public class ConsultationUpdateDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [ValidConsultationDate]
        public DateTime Date { get; set; }
        [Required]
        public string Status { get; set; }
    }
}