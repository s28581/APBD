using System.ComponentModel.DataAnnotations;

namespace APBDProbnyKol2.Models;

public class Wytwornia
{
    [Key]
    public int IdWytwornia { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string Nazwa { get; set; }
    
    public ICollection<Album> Albums { get; set; }
}