using System.ComponentModel.DataAnnotations;

namespace Lab1.Areas.ProjectManagement.Models;

public class Project
{
    /// <summary>
    ///  The unique identifier for the project
    /// </summary>
    public int ProjectId { get; set; }
    
    /// <summary>
    ///  Required field describing the projects name  
    /// </summary>
    [Display(Name = "Project Name")]
    [Required]
    [StringLength(100, ErrorMessage = "Project name cannot be longer than 100 characters.")]
    public required string Name { get; set; }
    
    [Display(Name = "Project Description")]
    [DataType(DataType.MultilineText)]
    [StringLength(500, ErrorMessage = "Project Description cannot be longer than 500 characters.")]
    public string? Description { get; set; }
    
    
    [Display(Name = "Project Start Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    
    
    [Display(Name = "Project End Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
    
    [Display(Name = "Project Status")]
    public string? Status { get; set; }
    
    //one to many: A project can have many tasks
    public List<ProjectTask>? Tasks { get; set; } = new();

}