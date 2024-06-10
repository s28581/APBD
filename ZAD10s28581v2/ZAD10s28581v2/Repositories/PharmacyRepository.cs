using Microsoft.EntityFrameworkCore;
using ZAD10s28581v2.Context;
using ZAD10s28581v2.DTOs;
using ZAD10s28581v2.Models;

namespace ZAD10s28581v2.Repositories;

public class PharmacyRepository : IPharmacyRepository
{
    private readonly DataContext _context;

    public PharmacyRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(PatientDTO patientDto)
    {
        return await _context.Patients.AnyAsync(x =>
            x.FirstName == patientDto.FirstName
            && x.LastName == patientDto.LastName
            && x.Birthdate == patientDto.Birthdate);
    }

    public async Task<PrescriptionDTO> AddPrescription(PrescriptionInDTO prescriptionInDto)
    {
        foreach (var medicamentDto in prescriptionInDto.MedicamentDtos)
        {
            
        }
        PatientDTO PatientIn = prescriptionInDto.PatientDto;
        if (DoesPatientExist(PatientIn).Result)
        {
            Patient NewP = new Patient
            {
                Birthdate = PatientIn.Birthdate,
                FirstName = PatientIn.FirstName,
                LastName = PatientIn.LastName,
                Prescriptions = new List<Prescription>()
            };
            await _context.Patients.AddAsync(NewP);
        }
    }
}