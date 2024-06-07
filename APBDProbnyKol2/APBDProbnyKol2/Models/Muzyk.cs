using System.ComponentModel.DataAnnotations;

namespace APBDProbnyKol2.Models;

public class Muzyk
{
    [Key]
    public int IdMuzyk { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string Imie { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string Nazwisko { get; set; }
    
    [MaxLength(50)]
    public string Pseudonim { get; set; }
    
    public ICollection<WykonawcaUtworu> WykonawcaUtworu { get; set; }
}