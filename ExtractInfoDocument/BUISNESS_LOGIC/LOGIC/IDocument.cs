using Azure.AI.DocumentIntelligence;

namespace ExtractInfoDocument.BUISNESS_LOGIC.LOGIC
{
    public interface IDocument
    {
        DTOS.Document TransformDataAzure(AnalyzedDocument analyzedDocument);
    }
}