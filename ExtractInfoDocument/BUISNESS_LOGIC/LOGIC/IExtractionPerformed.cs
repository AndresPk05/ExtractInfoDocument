using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;

namespace ExtractInfoDocument.BUISNESS_LOGIC.LOGIC
{
    public interface IExtractionPerformed
    {
        Task SaveTracking(DocumentRequest documentRequest);
    }
}