namespace etip.Models;

public class GatePaymentOption
{
    public int GateId { get; set; }
    public int PaymentMethodId { get; set; }
    public bool IsCash { get; set; }
    public bool IsCashless { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public Gate Gate { get; set; } = null!;
}