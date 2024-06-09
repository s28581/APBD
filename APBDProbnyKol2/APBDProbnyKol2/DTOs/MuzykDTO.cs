using APBDProbnyKol2.Models;

namespace APBDProbnyKol2.DTOs;

public record MuzykDTO(string Imie, string Nazwisko, string? Pseudonim, List<UtworDTO> utwory);