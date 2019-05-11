using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationSample2.Models.Home
{
    public class ItemModel
    {
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "The password must have at least ...")]
        public string Name { get; set; }

        [Range(5, 28)]
        public int Number { get; set; }
    }
}