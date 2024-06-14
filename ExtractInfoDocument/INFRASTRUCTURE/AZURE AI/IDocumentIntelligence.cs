
using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;

namespace ExtractInfoDocument.INFRASTRUCTURE.AZURE_AI
{
    public interface IDocumentIntelligence
    {
        Task<BUISNESS_LOGIC.DTOS.Document> AnalyzeDocument(string document);
    }
}