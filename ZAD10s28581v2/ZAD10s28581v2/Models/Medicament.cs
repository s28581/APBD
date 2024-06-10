using System.ComponentModel.DataAnnotations;

namespace ZAD10s28581v2.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [MaxLength(100)]
    []
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}