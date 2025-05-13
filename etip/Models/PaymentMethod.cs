namespace etip.Models;

public class PaymentMethod : BaseModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public bool IsActive { get; set; }
    
}