using Evolent.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository ContactRepository { get; }
        void Complete();
    }
}
