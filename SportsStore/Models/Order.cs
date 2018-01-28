using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartItem> Contents { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a Zip Code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a Country name")]
        public string Country { get; set; }
        public bool IsGift { get; set; }    

    }
}
