namespace ExtractInfoDocument.BUISNESS_LOGIC.DTOS;

public class Document()
{
    public Person Sender { get; set; }
    public Person Recipient { get; set; } 
    public string? Address {  get; set; }
    public string Date { get; set; }
    public string Total { get; set; }
    public string SubTotal { get; set; }
    public string TotalTax { get; set; }
    public List<Detail> Details { get; set; }
}
