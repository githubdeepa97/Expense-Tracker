using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models;
public class Expenditure
{
    [Key]
    public int Id { get; set;}
    [ForeignKey("Id")]
    public int UserId { get; set;}
    public User User{ get; set;}
    [ForeignKey("Id")]
    public int ItemId { get; set; }
    public Item Item{ get; set; }   
    public decimal Amount{ get; set; }
}