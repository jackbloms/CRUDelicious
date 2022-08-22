
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRUDelicious.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    [MaxLength(45, ErrorMessage = "Name must be less than 45 chars")]
    [Display(Name = "Name of Dish")]
    public string Name { get; set; }

    [Required]
    [MaxLength(45, ErrorMessage = "Chef must be less than 45 chars")]
    [Display(Name = "Chef's Name")]
    public string Chef { get; set; }

    [Required]
    [Display(Name = "Tastiness Level")]
    public int Tastiness { get; set; }

    [Required]
    [Display(Name = "# of Calories")]
    public int Calories { get; set; }

    [Required]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}