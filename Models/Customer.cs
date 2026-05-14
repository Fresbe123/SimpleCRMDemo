using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMDemo.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }

        public string? Company { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();

    }
}