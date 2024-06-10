using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAD10s28581v2.Models;

public class PrescriptionMedicament
{
    [Key, Column(Order = 0)]
    public int IdMedicament { get; set; }
    
    [Key, Column(Order = 1)]
    public int IdPrescription { get; set; }
    
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicaments { get; set; }
    
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescriptions { get; set; }
    
    public int? Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}