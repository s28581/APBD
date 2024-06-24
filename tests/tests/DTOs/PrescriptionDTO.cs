namespace tests.Models
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorLastName { get; set; }

        public PrescriptionDTO(int idPrescription, DateTime date, DateTime dueDate, string patientLastName, string doctorLastName)
        {
            IdPrescription = idPrescription;
            Date = date;
            DueDate = dueDate;
            PatientLastName = patientLastName;
            DoctorLastName = doctorLastName;
        }
    }
}