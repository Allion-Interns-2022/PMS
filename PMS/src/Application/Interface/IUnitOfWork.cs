using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISiblingRepository SiblingRepository { get; }
        Task CompleteAsync();
    }
}
