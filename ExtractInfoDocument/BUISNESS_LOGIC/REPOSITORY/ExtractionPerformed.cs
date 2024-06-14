using ExtractInfoDocument.INFRASTRUCTURE.MODEL;

namespace ExtractInfoDocument.BUISNESS_LOGIC.REPOSITORY
{
    public class ExtractionPerformed : IExtractionPerformed
    {
        private readonly ExtractionInfoDocumentContext _context;

        public ExtractionPerformed(ExtractionInfoDocumentContext context)
        {
            _context = context;
        }

        public async Task Add(ENTITIES.ExtractionPerformed extractionPerformed)
        {
            _context.ExtractionPerformeds.Add(extractionPerformed);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<ENTITIES.ExtractionDetail> extractionDetail)
        {
            _context.ExtractionDetails.AddRange(extractionDetail);
            await _context.SaveChangesAsync();
        }
    }
}
