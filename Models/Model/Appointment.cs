using Ha.appointment.Model.Identity;

namespace Ha.appointment.Models.Model
{
    public class Appointment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Clock { get; set; }
        public virtual Staff Staff { get; set; }
        //public virtual MyUser MyUser { get; set; }

    }
}
