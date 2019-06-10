using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopRepositoryImplementation.Core.Domain;

namespace CarShopRepositoryImplementation.Core.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetTopSellingCars(int pageIndex, int pageSize);
        IEnumerable<Car> GetTopSellingModels(int pageIndex, int pageSize);
        IEnumerable<Car> GetTopSellingMake(int pageIndex, int pageSize);
    }
}
