namespace ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES
{
    public class ExtractionPerformed
    {
        public Guid Id { get; set; }
        public string License { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public List<ExtractionDetail> Details { get; set; }
    }
}
