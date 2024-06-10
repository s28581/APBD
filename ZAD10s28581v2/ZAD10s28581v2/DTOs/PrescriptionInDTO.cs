namespace ZAD10s28581v2.DTOs;

public record PrescriptionInDTO(PatientDTO PatientDto, PrescriptionDTO PrescriptionDto, ICollection<MedicamentDTO> MedicamentDtos);