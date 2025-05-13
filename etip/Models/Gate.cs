namespace etip.Models;

public class Gate
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public bool? Type { get; set; }
    public bool? Status { get; set; }
    public bool? Has_Attendence { get; set; }
    public bool? In_or_Out { get; set; }
}