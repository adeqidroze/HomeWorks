namespace mvcWebApp1
{
    public class Customer
    {
        public enum DoctorType { Dentist, Ophtalmologist, Pediatrition }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DoctorType Doctor { get; set; }
        public string Time { get; set; }
    }
}
