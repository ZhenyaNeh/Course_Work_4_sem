using artTech.Models;
using artTech.Models.Peeson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Data.UnitOfWork
{
    internal interface IMyUnitOfWorck : IDisposable
    {
        IMyRepository<User> Repository { get; }
        void Save();
    }
}
