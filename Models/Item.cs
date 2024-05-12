using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTracker.Models;

namespace ExpenseTracker.Models;

public class Item
{
    [Key]
 public int Id { get; set; }
 [Required]
 public string? Name { get; set; }
 [Required]
 public int Price { get; set;}
 public string Description { get; set;}
 [ForeignKey("Id")]
 public int? ItemGroupId { get; set; }
 public ItemGroup ItemGroup{ get; set; }

 
}
