using Application.Interface;
using Core;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class SiblingRepository : GenericRepository<Sibling>, ISiblingRepository
    {
        public SiblingRepository(PMSContext context) : base(context)
        {
        }

        public async Task<List<Sibling>> GetSiblingByStudentId(int id)
        {
            var siblingExist = await _DbSet.Where(m => m.StudentId == id).ToListAsync();
            return siblingExist;
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            var siblingExist = await _DbSet.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (siblingExist == null) return false;

            _DbSet.Remove(siblingExist);
            return true;
        }

        public override async Task<bool> UpdateEntity(Sibling entity)
        {
            var siblingExist = await _DbSet.Where(p => p.Id == entity.Id).FirstOrDefaultAsync();
            if (siblingExist != null)
            {

                siblingExist.FullName = entity.FullName;
                siblingExist.EducationalInstitute = entity.EducationalInstitute;
                siblingExist.AcademicYear = entity.AcademicYear;
                siblingExist.StudentId = entity.StudentId;

                return true;
            }

            return false;
        }


    }
}
