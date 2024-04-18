using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AgileToDo.Models;

public class IssueModel
{
    public Guid Id { get; set; }

    [DisplayName("Title")]
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    [DisplayName("Description")]
    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }

    [DisplayName("Date created")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
    public DateTime? CreatedAt { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    [DisplayName("Deadline")]
    [Required(ErrorMessage = "Deadline is required")]
    public DateTime Deadline { get; set; }

    public bool Resolved { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    [DisplayName("Date resolved")]
    public DateTime? ResolvedAt { get; set; }

    [DisplayName("Created by")]
    public string? CreatedBy { get; set; }
    
    [DisplayName("Resolved by")]
    public string? ResolvedBy { get; set; }

    public IssueModel()
    {

    }
}
