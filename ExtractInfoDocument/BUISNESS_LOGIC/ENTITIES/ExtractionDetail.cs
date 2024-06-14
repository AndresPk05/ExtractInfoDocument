namespace ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES;

public class ExtractionDetail
{
    public Guid Id { get; set; }
    public string NameDocument { get; set; }
    public Guid ExtractionPerformedId { get; set; }
    public ExtractionPerformed ExtractionPerformed { get; set; }
}
