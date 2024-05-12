namespace ExpenseTracker.Models;
public class Expense
{
    public IEnumerable<Item> items {get;set;}
    public IEnumerable<User> users {get;set;}
    public Expenditure expenditure{get;set;}
}