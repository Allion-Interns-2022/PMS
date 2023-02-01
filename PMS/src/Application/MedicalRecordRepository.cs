using Application.Interface;
using Core;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class MedicalRecordRepository : GenericRepository<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(PMSContext context) : base(context)
        {
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordByPatientId(int id)
        {
            var medicalRecordExist = await _DbSet.Where(m => m.PatientId == id).ToListAsync();
            return medicalRecordExist;
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            var medicalRecordExist = await _DbSet.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (medicalRecordExist == null) return false;

            _DbSet.Remove(medicalRecordExist);
            return true;
        }

        public override async Task<bool> UpdateEntity(MedicalRecord entity)
        {
            var medicalRecordExist = await _DbSet.Where(p => p.Id == entity.Id).FirstOrDefaultAsync();
            if (medicalRecordExist != null)
            {

                medicalRecordExist.SampleCollectedDate = entity.SampleCollectedDate;
                medicalRecordExist.SugarMmol = entity.SugarMmol;
                medicalRecordExist.TemperatureCelcius = entity.TemperatureCelcius;
                medicalRecordExist.PlateletMmol = entity.PlateletMmol;
                medicalRecordExist.HemoglobinGdl = entity.HemoglobinGdl;
                medicalRecordExist.PatientId = entity.PatientId;

                return true;
            }

            return false;
        }


    }
}
