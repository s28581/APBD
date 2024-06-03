﻿using PharmacyApi.DTOs;
using PharmacyApi.Repositories;

namespace PharmacyApi.Services;

public class PharmacyService : IPharmacyService
{
    private readonly IPharmacyRepository _pharmacyRepository;

    public PharmacyService(IPharmacyRepository pharmacyRepository)
    {
        _pharmacyRepository = pharmacyRepository;
    }
    public async Task<Errors> AddPrescription(PrescriptionInDTO prescriptionInDto)
    {
        if (prescriptionInDto.medicaments.Count > 10)
            return Errors.TooManyMedicaments;

        if (prescriptionInDto.DueDate < prescriptionInDto.Date)
            return Errors.WrongDate;
        
        if (!await _pharmacyRepository.DoesPatientExist(prescriptionInDto.patient.IdPatient))
            await _pharmacyRepository.AddPatient(prescriptionInDto.patient);

        foreach (var medicament in prescriptionInDto.medicaments)
        {
            if (!await _pharmacyRepository.DoesMedicamentExist(medicament.IdMedicament))
                return Errors.NotFoundMecicament;
        }

        int idPrescription = await _pharmacyRepository.AddPrescription(prescriptionInDto);

        foreach (var medicament in prescriptionInDto.medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicamentDTO
            (
                medicament.IdMedicament, 
                idPrescription, 
                medicament.Dose, 
                "Not included"
                );

            await _pharmacyRepository.AddPrescriptionMedicament(prescriptionMedicament);
        }
        
        return Errors.Good;
    }

    public async Task<PatientDataDTO> GetPatientData(int IdPatient)
    {
        return await _pharmacyRepository.GetPatientData(IdPatient);
    }
}