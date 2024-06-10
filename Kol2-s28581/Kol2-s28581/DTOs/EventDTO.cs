using Kol2_s28581.Models;

namespace Kol2_s28581.DTOs;

public record EventDTO(ICollection<OrganiserDTO> MainOrganisersDtos, ICollection<OrganiserDTO> OrganisersDtos, string Name, DateTime DateFro, DateTime? DateTo);