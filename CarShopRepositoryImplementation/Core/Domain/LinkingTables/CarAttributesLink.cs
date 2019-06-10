using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarShopRepositoryImplementation.Core.Domain.LinkingTables
{
    public class CarAttributesLink
    {
        [Key]
        public int Id { get; set; }

        #region Entity Framework

        [ForeignKey("Attributes")]
        public int AttributesId { get; set; }
        public Attribute Attributes { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        #endregion
    }
}