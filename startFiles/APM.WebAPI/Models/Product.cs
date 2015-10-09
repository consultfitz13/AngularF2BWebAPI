using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public Product()
        {
            ReleaseDate = DateTime.Now;
        }

        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Code is required", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Product Code Minimum Length is 6 characters")]
        public string ProductCode { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage="Product Name is required",AllowEmptyStrings=false)]
        [MinLength(5, ErrorMessage = "Product Name Minimum Length is 5 characters")]
        [MaxLength(11, ErrorMessage = "Product Name Maximum Length is 11 characters")]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}