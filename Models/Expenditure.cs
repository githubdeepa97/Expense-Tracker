using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Models;
public class Expenditure
{
    [Key]
    public int Id { get; set;}
    [ForeignKey("Id")]
    public string UserId { get; set;}
    public IdentityUser User{ get; set;}
    [ForeignKey("Id")]
    public int ItemId { get; set; }
    public Item Item{ get; set; }   
    public decimal Amount{ get; set; }
}