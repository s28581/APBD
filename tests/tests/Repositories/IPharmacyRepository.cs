
using tests.Models;

namespace tests.Repositories;

public interface IPharmacyRepository
{
    IEnumerable<PrescriptionDTO> GetPrescriptions(string? doctorLastName);
    PrescriptionDTO AddPrescription(PrescriptionCreateDto prescriptionCreateDto);
    PrescriptionDTO GetPrescriptionById(int id);
}