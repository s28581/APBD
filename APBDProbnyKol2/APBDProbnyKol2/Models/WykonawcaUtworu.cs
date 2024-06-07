using System.ComponentModel.DataAnnotations;

namespace APBDProbnyKol2.Models;

public class WykonawcaUtworu
{
    [Key]
    public int IdMuzyk { get; set; }
    
    [Key]
    public int IdUtwor { get; set; }
    
    public Muzyk Muzyk { get; set; }

    public Utwor Utwor { get; set; }
}