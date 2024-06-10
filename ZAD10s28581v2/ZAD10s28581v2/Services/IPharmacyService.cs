using ZAD10s28581v2.DTOs;
using ZAD10s28581v2.Enums;

namespace ZAD10s28581v2.Services;

public interface IPharmacyService
{
   Task<Errors> AddPrescription(PrescriptionInDTO prescriptionInDto, CancellationToken cancellationToken);
}