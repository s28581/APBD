using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<bool> DoesPatientExist(PatientDTO patientDto, CancellationToken cancellationToken)
    {
        return await _context.Patients.AnyAsync(x =>
            x.FirstName == patientDto.FirstName
            && x.LastName == patientDto.LastName
            && x.Birthdate == patientDto.Birthdate);
    }
    
    public async Task<bool> DoesMedicamentExist(MedicamentDTO medicamentDto, CancellationToken cancellationToken)
    {
        return await _context.Medicaments.Where(x =>
            x.Name == medicamentDto.Name).AnyAsync(cancellationToken);
    }

    public async Task<int> AddPatient(PatientDTO patientDto, CancellationToken cancellationToken)
    {
        Patient result = new Patient
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            Birthdate = patientDto.Birthdate,
            Prescriptions = new List<Prescription>()
        };
        await _context.Patients.AddAsync(result, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return result.IdPatient;
    }
    
    public async Task<int> AddPrescription(PrescriptionDTO prescriptionDto, CancellationToken cancellationToken)
    {
        Prescription result = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdDoctor = prescriptionDto.IdDoctor,
            IdPatient = prescriptionDto.IdPatient
        };
        await _context.Prescriptions.AddAsync(result, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return result.IdPrescription;
    }
    
    /*public async Task<int> AddPrescription(PrescriptionInDTO prescriptionInDto, CancellationToken cancellationToken)
    {
        if (prescriptionInDto.MedicamentDtos.Count > 10)
        {
            return -1;
        }
        foreach (var medicamentDto in prescriptionInDto.MedicamentDtos)
        {
            if (!await DoesMedicimentExist(medicamentDto, cancellationToken))
            {
                return -2;
            }
        }
        PatientDTO patientDtoIn = prescriptionInDto.PatientDto;
        Patient patientIn;
        if (await DoesPatientExist(patientDtoIn, cancellationToken))
        {
            patientIn = new Patient
            {
                Birthdate = patientDtoIn.Birthdate,
                FirstName = patientDtoIn.FirstName,
                LastName = patientDtoIn.LastName,
                Prescriptions = new List<Prescription>()
            };
            await _context.Patients.AddAsync(patientIn, cancellationToken);
        }
        else
        {
            patientIn
        }
        
    }*/
}