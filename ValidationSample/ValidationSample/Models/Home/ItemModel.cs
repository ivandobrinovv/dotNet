using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationSample.Models.Home
{
    public class ItemModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(5)]
        public string Name { get; set; }
        
        [Display(Name = "Число")]
        public int Number { get; set; }
    }
}