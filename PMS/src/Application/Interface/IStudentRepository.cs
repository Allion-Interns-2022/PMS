using Core.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IStudentRepository : IGenericRepository<HostelStudent>
    {
        Task<HostelStudent> GetStudentByName(string name);
    }
}
