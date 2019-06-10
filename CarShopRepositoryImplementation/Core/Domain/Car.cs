using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarShopRepositoryImplementation.Core.Domain.LinkingTables;

namespace CarShopRepositoryImplementation.Core.Domain
{
    public class Car
    {
        public Car()
        {
            Shops = new HashSet<Shop>();
            CarAttributesLinks = new HashSet<CarAttributesLink>();
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Car Model")]
        [Required(ErrorMessage = "Please enter the car model name.")]
        public string CarModel { get; set; }
        [Display(Name = "Car Make")]
        [Required(ErrorMessage = "Please enter the car make.")]
        public string CarMake { get; set; }

        #region Entity Framework Links
        [ForeignKey("Shop")]
        public ICollection<Shop> Shops { get; set; }
        public ICollection<CarAttributesLink> CarAttributesLinks { get; set; }
        #endregion
    }
}