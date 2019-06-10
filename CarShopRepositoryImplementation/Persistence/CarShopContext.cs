using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarShopRepositoryImplementation.Core.Domain;
using CarShopRepositoryImplementation.Persistence.EntityConfigurations;

namespace CarShopRepositoryImplementation.Persistence
{
    public class CarShopContext : DbContext
    {
        public CarShopContext() : base("name=CarShopContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Core.Domain.Attribute> Attributes { get; set; }
        public virtual DbSet<Core.Domain.LinkingTables.CarAttributesLink> CarAttributeLinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarConfiguration());
            modelBuilder.Configurations.Add(new CarAttributesLinkConfiguration());
        }
    }
}