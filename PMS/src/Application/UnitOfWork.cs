using Application.Interface;
using Core.Interface;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected PMSContext _context { get; set; }
        public IUserRepository UserRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }
        public IMedicalRecordRepository MedicalRecordRepository { get; private set; }

        public UnitOfWork(PMSContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            PatientRepository = new PatientRepository(_context);
            MedicalRecordRepository= new MedicalRecordRepository(_context);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
