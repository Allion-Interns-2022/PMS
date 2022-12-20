using Application.Interface;
using Core;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(PMSContext context) : base(context)
        {
        }

        public async Task<Patient> GetPatientByName(string name)
        {
            return await _DbSet.Where(p => p.Name.ToLower().Contains(name.ToLower())).FirstOrDefaultAsync();
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            var patientExist = await _DbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (patientExist == null) return false;

            _DbSet.Remove(patientExist);
            return true;
        }

        public override async Task<bool> UpdateEntity(Patient entity)
        {
            var patientExist = await _DbSet.Where(p => p.Id == entity.Id).FirstOrDefaultAsync();
            if (patientExist != null)
            {
                patientExist.Name = entity.Name;
                patientExist.DOB = entity.DOB;
                patientExist.WeightKG = entity.WeightKG;
                patientExist.HeightCM = entity.HeightCM;
                patientExist.Address = entity.Address;
                patientExist.Contact = entity.Contact;
                patientExist.EmergencyContact = entity.EmergencyContact;

                return true;
            }

            return false;
        }


    }
}