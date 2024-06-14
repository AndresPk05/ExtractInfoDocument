using ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES;

namespace ExtractInfoDocument.BUISNESS_LOGIC.REPOSITORY
{
    public interface IExtractionPerformed
    {
        Task AddRange(List<ExtractionDetail> extractionDetail);
        Task Add(ENTITIES.ExtractionPerformed extractionPerformed);
    }
}