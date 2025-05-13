namespace etip.Models;

public class PaymentMethodOptions : BaseModel
{
    public int Gate_Id { get; set; }
    public int PaymentMethod_Id { get; set; }
    public bool Is_Cash { get; set; }
    public bool Is_Cashless { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    public Gate Gate { get; set; }
    
}