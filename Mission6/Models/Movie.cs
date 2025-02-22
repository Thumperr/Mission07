using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    [Required(ErrorMessage = "CategoryId is required")]
    public int? CategoryId { get; set; }
    
    public Category? Category { get; set; }
    
    [Required(ErrorMessage = "Please enter the name of the movie")]
    public string Title { get; set; }
    
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; } = 1888;
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    [Required]
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required]
    public bool CopiedToPlex { get; set; }
    
    public string? Notes { get; set; }
}