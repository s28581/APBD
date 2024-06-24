using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using tests.Models;

namespace tests.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly IConfiguration _configuration;

        public PharmacyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<PrescriptionDTO> GetPrescriptions(string doctorLastName)
        {
            var prescriptions = new List<PrescriptionDTO>();

            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    if (string.IsNullOrEmpty(doctorLastName))
                    {
                        sqlCommand.CommandText = @"
                            SELECT p.IdPrescription, p.Date, p.DueDate, pa.LastName AS PatientLastName, d.LastName AS DoctorLastName
                            FROM Prescription p
                            JOIN Patient pa ON p.IdPatient = pa.IdPatient
                            JOIN Doctor d ON p.IdDoctor = d.IdDoctor
                            ORDER BY p.Date DESC";
                    }
                    else
                    {
                        sqlCommand.CommandText = @"
                            SELECT p.IdPrescription, p.Date, p.DueDate, pa.LastName AS PatientLastName, d.LastName AS DoctorLastName
                            FROM Prescription p
                            JOIN Patient pa ON p.IdPatient = pa.IdPatient
                            JOIN Doctor d ON p.IdDoctor = d.IdDoctor
                            WHERE d.LastName = @doctorLastName
                            ORDER BY p.Date DESC";
                        sqlCommand.Parameters.AddWithValue("@doctorLastName", doctorLastName);
                    }

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var prescription = new PrescriptionDTO(
                                idPrescription: dataReader.GetInt32(dataReader.GetOrdinal("IdPrescription")),
                                date: dataReader.GetDateTime(dataReader.GetOrdinal("Date")),
                                dueDate: dataReader.GetDateTime(dataReader.GetOrdinal("DueDate")),
                                patientLastName: dataReader.GetString(dataReader.GetOrdinal("PatientLastName")),
                                doctorLastName: dataReader.GetString(dataReader.GetOrdinal("DoctorLastName"))
                            );

                            prescriptions.Add(prescription);
                        }
                    }
                }
            }

            return prescriptions;
        }
        
        public PrescriptionDTO AddPrescription(PrescriptionCreateDto prescriptionCreateDto)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = @"
                        INSERT INTO Prescription (Date, DueDate, IdPatient, IdDoctor)
                        OUTPUT INSERTED.IdPrescription, INSERTED.Date, INSERTED.DueDate, 
                               (SELECT LastName FROM Patient WHERE IdPatient = INSERTED.IdPatient) AS PatientLastName,
                               (SELECT LastName FROM Doctor WHERE IdDoctor = INSERTED.IdDoctor) AS DoctorLastName
                        VALUES (@Date, @DueDate, @IdPatient, @IdDoctor)";

                    sqlCommand.Parameters.AddWithValue("@Date", prescriptionCreateDto.Date);
                    sqlCommand.Parameters.AddWithValue("@DueDate", prescriptionCreateDto.DueDate);
                    sqlCommand.Parameters.AddWithValue("@IdPatient", prescriptionCreateDto.IdPatient);
                    sqlCommand.Parameters.AddWithValue("@IdDoctor", prescriptionCreateDto.IdDoctor);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return new PrescriptionDTO(
                                idPrescription: dataReader.GetInt32(dataReader.GetOrdinal("IdPrescription")),
                                date: dataReader.GetDateTime(dataReader.GetOrdinal("Date")),
                                dueDate: dataReader.GetDateTime(dataReader.GetOrdinal("DueDate")),
                                patientLastName: dataReader.GetString(dataReader.GetOrdinal("PatientLastName")),
                                doctorLastName: dataReader.GetString(dataReader.GetOrdinal("DoctorLastName"))
                            );
                        }
                    }
                }
            }

            throw new Exception("Failed to insert prescription");
        }

        public PrescriptionDTO GetPrescriptionById(int id)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = @"
                        SELECT p.IdPrescription, p.Date, p.DueDate, pa.LastName AS PatientLastName, d.LastName AS DoctorLastName
                        FROM Prescription p
                        JOIN Patient pa ON p.IdPatient = pa.IdPatient
                        JOIN Doctor d ON p.IdDoctor = d.IdDoctor
                        WHERE p.IdPrescription = @Id";
                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return new PrescriptionDTO(
                                idPrescription: dataReader.GetInt32(dataReader.GetOrdinal("IdPrescription")),
                                date: dataReader.GetDateTime(dataReader.GetOrdinal("Date")),
                                dueDate: dataReader.GetDateTime(dataReader.GetOrdinal("DueDate")),
                                patientLastName: dataReader.GetString(dataReader.GetOrdinal("PatientLastName")),
                                doctorLastName: dataReader.GetString(dataReader.GetOrdinal("DoctorLastName"))
                            );
                        }
                    }
                }
            }

            return null;
        }
    }
}
