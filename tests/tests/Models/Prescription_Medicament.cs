namespace tests.Models;

public class Prescription_Medicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int Dose { get; set; }
    public string Details { get; set; }
    public Medicament Medicament { get; set; }
    public Prescription Prescription { get; set; }
    
    public Prescription_Medicament(int dose, string details, Medicament medicament, Prescription prescription)
    {
        Dose = dose;
        Details = details;
        Medicament = medicament;
        Prescription = prescription;
    }

}