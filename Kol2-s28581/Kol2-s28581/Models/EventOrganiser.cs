using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2_s28581.Models;

public class EventOrganiser
{
    [Key, Column(Order = 0)]
    public int IdEvent { get; set; }
    
    [Key, Column(Order = 1)]
    public int IdOrganiser { get; set; }
    
    [ForeignKey(nameof(IdEvent))]
    public Event Event { get; set; }
    
    [ForeignKey(nameof(IdOrganiser))]
    public Organiser Organiser { get; set; }
    
    [Required]
    public bool MainOrganiser { get; set; }
}