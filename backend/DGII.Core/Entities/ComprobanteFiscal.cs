namespace DGII.Core.Entities;

public class ComprobanteFiscal
{
    public int Id { get; set; }
    public string RncCedula { get; set; } = string.Empty;
    public string NCF { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public decimal Itbis18 { get; set; }
}