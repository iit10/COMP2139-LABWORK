using Lab1.Areas.ProjectManagement.Models;
using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define one-to-many relationship 
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks)  // One project has (potentially) many tasks
            .WithOne(t => t.Project) // Each ProjectTask belongs to one Project
            .HasForeignKey(t => t.ProjectId) // Foreign key in projectTask table
            .OnDelete(DeleteBehavior.Cascade); // Cascade Delete ProjectTask when a Project is deleted 
        
        // Ensure DateTime fields are stored as UTC
        modelBuilder.Entity<Project>()
            .Property(p => p.StartDate)
            .HasColumnType("timestamp with time zone");
            
        modelBuilder.Entity<Project>()
            .Property(p => p.EndDate)
            .HasColumnType("timestamp with time zone");

       
        modelBuilder.Entity<Project>().HasData(
            new Project 
            { 
                ProjectId = 1, 
                Name = "Assignment 1", 
                Description = "COMP2139 - Assignment 1",
                StartDate = new DateTime(2025, 03, 01, 0, 0, 0, DateTimeKind.Utc),  
                EndDate = new DateTime(2025, 03, 15, 0, 0, 0, DateTimeKind.Utc)  
            },
            new Project 
            { 
                ProjectId = 2, 
                Name = "Assignment 2", 
                Description = "COMP2139 - Assignment 2",
                StartDate = new DateTime(2025, 03, 16, 0, 0, 0, DateTimeKind.Utc),  
                EndDate = new DateTime(2025, 03, 30, 0, 0, 0, DateTimeKind.Utc)  
            }
        );
    }
}
