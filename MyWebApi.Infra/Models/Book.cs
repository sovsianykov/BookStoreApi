
using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Infra.Models;

public record Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = String.Empty;

    [Required]
    [MaxLength(100)]
    public string Author { get; set; } = String.Empty;
}