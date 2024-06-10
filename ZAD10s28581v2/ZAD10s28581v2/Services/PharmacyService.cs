using ZAD10s28581v2.DTOs;
using ZAD10s28581v2.Enums;
using ZAD10s28581v2.Repositories;

namespace ZAD10s28581v2.Services;

public class PharmacyService : IPharmacyService
{
    private readonly PharmacyRepository _pharmacyRepository;

    public PharmacyService(PharmacyRepository pharmacyRepository)
    {
        _pharmacyRepository = pharmacyRepository;
    }

    public async Task<Errors> AddPrescription(PrescriptionInDTO prescriptionInDto, CancellationToken cancellationToken)
    {
        if (prescriptionInDto.MedicamentDtos.Count > 10)
            return Errors.TooManyMedicaments;

        if (prescriptionInDto.PrescriptionDto.DueDate < prescriptionInDto.PrescriptionDto.Date)
            return Errors.WrongDate;
        
        if (!await _pharmacyRepository.DoesPatientExist(prescriptionInDto.PatientDto, cancellationToken))
            await _pharmacyRepository.AddPatient(prescriptionInDto.PatientDto, cancellationToken);

        foreach (var medicament in prescriptionInDto.MedicamentDtos)
        {
            if (!await _pharmacyRepository.DoesMedicamentExist(medicament, cancellationToken))
                return Errors.MedicamentNotFound;
        }
    }
}