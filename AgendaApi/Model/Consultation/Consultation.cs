using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgendaApi.Validations;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Model.Consultation
{
    [Index(nameof(Date), IsUnique = true)]
    public class Consultation
    {
        [Key]
        public long Id { get; set; }
        [ValidConsultationDate]
        public DateTime Date { get; set; }
        public ConsultationStatus Status { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("DoctorId")]
        public User.User Doctor { get; set; }
        [ForeignKey("PatientId")]
        public Patient.Patient Patient { get; set; }
    }
}