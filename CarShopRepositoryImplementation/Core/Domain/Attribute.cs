using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarShopRepositoryImplementation.Core.Domain.LinkingTables;

namespace CarShopRepositoryImplementation.Core.Domain
{
    public class Attribute
    {
        public Attribute()
        {
            CarAttributesLinks = new HashSet<CarAttributesLink>();
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Car Attributes")]
        [Required]
        public string Name { get; set; }

        #region Entity Framework
        public ICollection<CarAttributesLink> CarAttributesLinks { get; set; }
        #endregion
    }
}