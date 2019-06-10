using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopRepositoryImplementation.Core.Domain;

namespace CarShopRepositoryImplementation.Core.Repositories
{
    public interface IShopRepository : IRepository<Shop>
    {
        Shop GetShopWithCars(int id);
    }
}
