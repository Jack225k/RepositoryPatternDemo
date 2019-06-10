using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarShopRepositoryImplementation.Core.Domain
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Shop Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Shop Address")]
        [Required]
        public string Address { get; set; }
        #region Entity Framework
        public ICollection<Car> Cars { get; set; }
        #endregion
    }
}