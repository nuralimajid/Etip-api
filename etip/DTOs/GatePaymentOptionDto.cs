namespace etip.DTOs;

public class GatePaymentOptionDto : IMapFrom<GatePaymentOption>
{
    public int Id { get; set; }
    public int GateId { get; set; }
    public int PaymentMethodId { get; set; }
    public bool IsCashOnly { get; set; } = false;
    public bool IsCashlessOnly { get; set; } = false;
    
    public GateDto Gate { get; set; }
    public PaymentMethodDto PaymentMethod { get; set; }
}