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
        IPatientRepository PatientRepository { get; }
        IMedicalRecordRepository MedicalRecordRepository { get; }
        Task CompleteAsync();
    }
}
