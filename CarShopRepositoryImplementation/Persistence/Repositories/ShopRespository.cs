using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CarShopRepositoryImplementation.Core.Domain;
using CarShopRepositoryImplementation.Core.Repositories;

namespace CarShopRepositoryImplementation.Persistence.Repositories
{
    public class ShopRespository : Repository<Shop>, IShopRepository
    {
        public ShopRespository(CarShopContext context) : base(context)
        {
            
        }

        public CarShopContext CarShopContext
        {
            get { return Context as CarShopContext;}
        }
        public Shop GetShopWithCars(int id)
        {
            throw new NotImplementedException();
        }
    }
}