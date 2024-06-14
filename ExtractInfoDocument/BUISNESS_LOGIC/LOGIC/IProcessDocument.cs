using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;

namespace ExtractInfoDocument.BUISNESS_LOGIC.LOGIC
{
    public interface IProcessDocument
    {
        Task<Result<List<DTOS.Document>>> ExtractInfoDocument(DocumentRequest request);
    }
}