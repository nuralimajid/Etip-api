namespace etip.Models;

public class GatePaymentOption : BaseModel
{
    public int GateId { get; set; }
    public int PaymentMethodId { get; set; }
    public bool IsCash { get; set; }
    public bool IsCashless { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    public Gate Gate { get; set; }
    
}