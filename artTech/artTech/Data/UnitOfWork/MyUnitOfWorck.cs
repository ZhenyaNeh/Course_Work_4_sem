using artTech.Models;
using artTech.Models.Peeson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Data.UnitOfWork
{
    internal class MyUnitOfWork : IMyUnitOfWorck
    {
        private readonly DbContext _context;
        public MyRepository<User> userRepository;
        private bool disposed = false;

        public MyUnitOfWork(DbContext context)
        {
            _context = context;
            userRepository = new MyRepository<User>(_context);
        }

        public IMyRepository<User> Repository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new MyRepository<User>(_context);
                return userRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
