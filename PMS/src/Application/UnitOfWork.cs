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
        public IStudentRepository StudentRepository { get; private set; }
        public ISiblingRepository SiblingRepository { get; private set; }

        public UnitOfWork(PMSContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            StudentRepository = new StudentRepository(_context);
            SiblingRepository = new SiblingRepository(_context);
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
