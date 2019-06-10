using CarShopRepositoryImplementation.Core.Domain;
using CarShopRepositoryImplementation.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CarShopRepositoryImplementation.Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarShopContext context) : base(context)
        {

        }

        public CarShopContext CarShopContext
        {
            get { return Context as CarShopContext; }
        }

        public IEnumerable<Car> GetTopSellingCars(int pageIndex, int pageSize)
        {
            return CarShopContext.Cars.OrderByDescending(c => c.CarMake).ToList();
        }

        public IEnumerable<Car> GetTopSellingModels(int pageIndex, int pageSize)
        {
            return CarShopContext.Cars
                .OrderBy(c => c.CarModel)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Car> GetTopSellingMake(int pageIndex, int pageSize)
        {
            return CarShopContext.Cars
                .OrderBy(c => c.CarMake)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        
    }
}