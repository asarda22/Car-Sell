using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSell.Models
{
    public class Car
    {
        public int Id { get; set; }

        public Brand Brand { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Please Select a brand")]
        public int BrandID { get; set; }

        public Model Model { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Please Select a model")]
        public int ModelID { get; set; }
   
        [Required(ErrorMessage = "Provide Year")]
        [Range(1975,2022)]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please Enter Mileage")]
        [Range(1, int.MaxValue, ErrorMessage = "Not within the valid mileage range")]
        public int Mileage { get; set; }


        public string Features { get; set; }

        [Required(ErrorMessage = "Please Provide Seller Name")]
        [StringLength(50)]
        public string SellerName { get; set; }

        [Required(ErrorMessage = "Please Provide Seller Email")]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        [StringLength(50)]
        public string SellerEmail { get; set; }

        [Required(ErrorMessage = "Please Provide Phone No.")]
        [Phone]
        [StringLength(15)]
        public string SellerPhone { get; set; }

        [Required(ErrorMessage = "Please Provide Price")]
        [Range(1, 999999999, ErrorMessage = "Not within the valid price range")]
        public int Price { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please Select A Currency")]
        public string Currency { get; set; }

        [Display(Name = "Image File")]
        [StringLength(100)]
        public string ImagePath { get; set; }
    }
}
