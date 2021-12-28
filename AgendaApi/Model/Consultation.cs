using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaApi.Model
{
    public class Consultation
    {
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("DoctorId")]
        public User.User Doctor { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}