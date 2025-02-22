using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class Category
{
    public int CategoryId { get; set; }  // Primary Key
    public string CategoryName { get; set; }
}