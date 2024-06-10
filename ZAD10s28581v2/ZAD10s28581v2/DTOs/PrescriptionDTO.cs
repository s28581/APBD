namespace ZAD10s28581v2.DTOs;

public record PrescriptionDTO(DateTime Date, DateTime DueDate, int IdDoctor, int IdPatient);