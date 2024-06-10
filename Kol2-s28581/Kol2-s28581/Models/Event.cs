using System.ComponentModel.DataAnnotations;

namespace Kol2_s28581.Models;

public class Event
{
    [Key]
    public int IdEvent { get; set; }
    
    [Required]
    [MaxLength(60)]
    public string Name { get; set; }
    
    [Required]
    public DateTime DateFro { get; set; }
    
    public DateTime? DateTo { get; set; }

    public ICollection<EventOrganiser> EventOrganisers { get; set; }
}