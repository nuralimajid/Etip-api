using System.ComponentModel.DataAnnotations;

namespace etip.Models;

public class StatusUser : BaseModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}