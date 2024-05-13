using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Models;
public class User : IdentityUser
{
    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }

}