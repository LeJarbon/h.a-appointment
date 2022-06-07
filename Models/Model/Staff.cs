namespace Ha.appointment.Models.Model
{
    public class Staff
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Photo { get; set; }
        public string About { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
