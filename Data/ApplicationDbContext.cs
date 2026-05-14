using CRMDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CRMDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "João Silva",
                    Email = "joao@email.com",
                    Phone = "(11) 99999-9999",
                    Company = "Tech Solutions",
                    CreatedAt = new DateTime(2024, 1, 1) 
                },
                new Customer
                {
                    Id = 2,
                    Name = "Maria Santos",
                    Email = "maria@email.com",
                    Phone = "(11) 88888-8888",
                    Company = "Marketing Pro",
                    CreatedAt = new DateTime(2024, 1, 1)
                }
            );

            modelBuilder.Entity<Opportunity>().HasData(
                new Opportunity
                {
                    Id = 1,
                    Title = "Website Development",
                    Description = "Complete website",
                    Value = 15000,
                    Stage = OpportunityStage.Proposal,
                    CustomerId = 1,
                    ExpectedCloseDate = new DateTime(2024, 2, 1),
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new Opportunity
                {
                    Id = 2,
                    Title = "Digital Marketing",
                    Description = "SEO and ads",
                    Value = 8000,
                    Stage = OpportunityStage.Negotiation,
                    CustomerId = 2,
                    ExpectedCloseDate = new DateTime(2024, 1, 15),
                    CreatedAt = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}
