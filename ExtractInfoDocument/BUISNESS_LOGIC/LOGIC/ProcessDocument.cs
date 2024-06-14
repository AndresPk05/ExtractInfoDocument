using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;
using ExtractInfoDocument.INFRASTRUCTURE.AZURE_AI;

namespace ExtractInfoDocument.BUISNESS_LOGIC.LOGIC;

public class ProcessDocument : IProcessDocument
{
    private readonly IDocumentIntelligence _documentIntelligence;
    private readonly IExtractionPerformed _extractionPerformed;

    public ProcessDocument(IDocumentIntelligence documentIntelligence, IExtractionPerformed extractionPerformed)
    {
        _documentIntelligence = documentIntelligence;
        _extractionPerformed = extractionPerformed;
    }

    public async Task<Result<List<DTOS.Document>>> ExtractInfoDocument(DocumentRequest request)
    {
        try
        {
            List<DTOS.Document> documents = new List<DTOS.Document>();
            foreach (var url in request.urlDocument)
            {
                var document = await _documentIntelligence.AnalyzeDocument(url);
                documents.Add(document);
            }

            await _extractionPerformed.SaveTracking(request);

            return new Result<List<DTOS.Document>>
            {
                Value = documents
            };
        }
        catch (Exception ex)
        {

            return new Result<List<DTOS.Document>>
            {
                Error = true,
                Message = ex.Message,
            };
        }
    }
}
