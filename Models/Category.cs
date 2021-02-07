using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTut.Models
{
    public class Category
    {
        // Identify that this is a primary key in SQL Server
        // using System.ComponentModel.DataAnnotations;
        [Key]
        public int Id { get; set; }

        // Required field validation
        [Required]
        public string Name { get; set; }
        // Define the asp-for="DisplayOrder" as Display Order
        // using System.ComponentModel.DataAnnotations; 
        [DisplayName("Display Order")]
        // Required field validation
        [Required]
        // Range must be 1 to infinite validation
        [Range(1, int.MaxValue, ErrorMessage = "Display Order must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
