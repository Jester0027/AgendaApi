using System.ComponentModel;

namespace AgendaApi.Model.Consultation
{
    public enum ConsultationStatus
    {
        Pending = 0,
        InWaitingRoom = 1,
        Done = 2,
        Canceled = 3
    }
}