using Azure;
using Azure.AI.DocumentIntelligence;
using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;
using ExtractInfoDocument.BUISNESS_LOGIC.LOGIC;

namespace ExtractInfoDocument.INFRASTRUCTURE.AZURE_AI;

public class DocumentIntelligence : IDocumentIntelligence
{
    private readonly IConfiguration _config;
    private string _endpoint;
    private string _key;
    private AzureKeyCredential _credential;
    private DocumentIntelligenceClient _client;
    private IDocument _document;

    public DocumentIntelligence(IConfiguration config, IDocument document)
    {
        _config = config;
        _endpoint = _config["Azure:EndPoint"];
        _key = _config["Azure:Key1"];
        _credential = new AzureKeyCredential(_key);
        _client = new DocumentIntelligenceClient(new Uri(_endpoint), _credential);
        _document = document;
    }

    public async Task<BUISNESS_LOGIC.DTOS.Document> AnalyzeDocument(string document)
    {
        // Call Azure AI to analyze the document
        AnalyzeDocumentContent content = new AnalyzeDocumentContent();
        content.UrlSource = new Uri(document);
        Operation<AnalyzeResult> operation = await _client.AnalyzeDocumentAsync(WaitUntil.Completed, BUISNESS_LOGIC.CONSTANTS.Document.Invoice, content);
        AnalyzeResult result = operation.Value;
        BUISNESS_LOGIC.DTOS.Document document1 = _document.TransformDataAzure(result.Documents[0]);
        return document1;
    }
}
