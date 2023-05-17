using Application.Interface;
using Core;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class StudentRepository : GenericRepository<HostelStudent>, IStudentRepository
    {
        public StudentRepository(PMSContext context) : base(context)
        {
        }

        public async Task<HostelStudent> GetStudentByName(string name)
        {
            return await _DbSet.Where(p => p.FullName.ToLower().Contains(name.ToLower())).FirstOrDefaultAsync();
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            var studentExist = await _DbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (studentExist == null) return false;

            _DbSet.Remove(studentExist);
            return true;
        }

        public override async Task<bool> UpdateEntity(HostelStudent entity)
        {
            var studentExist = await _DbSet.Where(p => p.Id == entity.Id).FirstOrDefaultAsync();
            if (studentExist != null)
            {
                studentExist.FullName = entity.FullName;
                studentExist.NIC = entity.NIC;
                studentExist.Gender = entity.Gender;
                studentExist.Address = entity.Address;
                studentExist.Contact = entity.Contact;
                studentExist.Distance = entity.Distance;
                studentExist.Remarks = entity.Remarks;
                studentExist.SubmitDate = entity.SubmitDate;
                studentExist.MaritalStatus = entity.MaritalStatus;
                studentExist.FatherOccupation= entity.FatherOccupation;
                studentExist.MotherOccupation= entity.MotherOccupation;
                studentExist.FatherIncome= entity.FatherIncome;
                studentExist.MotherIncome= entity.MotherIncome;

                return true;
            }

            return false;
        }


    }
}