using ZAD10s28581v2.DTOs;

namespace ZAD10s28581v2.Repositories;

public interface IPharmacyRepository
{
    Task<PrescriptionDTO> AddPrescription(PrescriptionInDTO prescriptionInDto);
}