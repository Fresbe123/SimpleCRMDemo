using System;
using System.ComponentModel.DataAnnotations;

namespace CRMDemo.Models
{
    public class Customers
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")] 
        [Display(Name = "Full Name")] 
        [StringLength(100)] 
        public string Name { get; set; }

        [Required]
        [EmailAddress] 
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Phone] 
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Company Name")]
        [StringLength(100)]
        public string Company { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public ICollection<Opportunity> Opportunities { get; set; }
    }
}