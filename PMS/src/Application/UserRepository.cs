using Application.Interface;
using Core;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PMSContext context) : base(context)
        {
        }

        public async Task<User> GetUserByName(string name)
        {
            var userExist = await _DbSet.Where(u => u.FirstName.ToLower() == name.ToLower()).FirstOrDefaultAsync();

            return userExist;
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            var userExist = await _DbSet.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (userExist == null) return false;

            _DbSet.Remove(userExist);
            return true;
        }

        public override async Task<bool> UpdateEntity(User entity)
        {
            var userExist = await _DbSet.Where(u => u.Id == entity.Id).FirstOrDefaultAsync();
            if (userExist != null) {

                userExist.FirstName = entity.FirstName;
                userExist.LastName = entity.LastName;
                userExist.Username = entity.Username;
                userExist.Password = entity.Password;
                userExist.LastModified = entity.LastModified;
                userExist.LastModifiedBy = entity.LastModifiedBy;

                return true;
            }

            return false;
        }
       
        
    }
}