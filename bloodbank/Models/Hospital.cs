using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bloodbank.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(500, ErrorMessage = "Address can't be longer than 500 characters")]
        public string Address { get; set; }
        public string Type { get; set; }
        [Required]
        public string Contact { get; set; }
        public string Details { get; set; }
    }
}