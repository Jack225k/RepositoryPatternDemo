using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopRepositoryImplementation.Core.Repositories;

namespace CarShopRepositoryImplementation.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }
        IShopRepository Shops { get; }
        int Complete();
    }
}
