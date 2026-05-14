using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMDemo.Models
{
    public class Opportunity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Opportunity Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Value")]
        public decimal Value { get; set; }

        [Required]
        [Display(Name = "Stage")]
        public OpportunityStage Stage { get; set; }

        [Display(Name = "Expected Close Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpectedCloseDate { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }

    public enum OpportunityStage
    {
        [Display(Name = "Prospecting")]
        Prospecting = 1,

        [Display(Name = "Qualification")]
        Qualification = 2,

        [Display(Name = "Proposal")]
        Proposal = 3,

        [Display(Name = "Negotiation")]
        Negotiation = 4,

        [Display(Name = "Closed Won")]
        ClosedWon = 5,

        [Display(Name = "Closed Lost")]
        ClosedLost = 6
    }
}