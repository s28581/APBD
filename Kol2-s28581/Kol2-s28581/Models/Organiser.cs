using System.ComponentModel.DataAnnotations;

namespace Kol2_s28581.Models;

public class Organiser
{
    [Key]
    public int IdOrganis { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<EventOrganiser> EventOrganisers { get; set; }
}