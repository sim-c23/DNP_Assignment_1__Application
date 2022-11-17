using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Todo
{
    /*https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/data-annotations*/
    [Key]
    public int Id { get; set; }
    public User Owner { get; private set;}
    [MaxLength(50)]
    public string Title { get; private set;}

    public bool IsCompleted { get; set; }

    public Todo(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }

    private Todo(){}
}