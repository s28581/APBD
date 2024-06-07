using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDProbnyKol2.Models;

public class Album
{
    [Key]
    public int IdAlbum { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string NazwaAlbumu { get; set; }
    
    [Required]
    public DateTime DataWydania { get; set; }
    
    [ForeignKey(nameof(IdWytwornia))]
    public int IdWytwornia { get; set; }
    
    public ICollection<Utwor> Utwors { get; set; }
}