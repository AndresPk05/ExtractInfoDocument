using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;
using ExtractInfoDocument.BUISNESS_LOGIC.ENTITIES;

namespace ExtractInfoDocument.BUISNESS_LOGIC.LOGIC;

public class ExtractionPerformed : IExtractionPerformed
{
    private readonly REPOSITORY.IExtractionPerformed _extractionPerformed;

    public ExtractionPerformed(REPOSITORY.IExtractionPerformed extractionPerformed)
    {
        _extractionPerformed = extractionPerformed;
    }

    public async Task SaveTracking(DocumentRequest documentRequest)
    {
        var extractionPerformed = new ENTITIES.ExtractionPerformed
        {
            Id = Guid.NewGuid(),
            License = documentRequest.license,
            Quantity = documentRequest.urlDocument.Length,
            Date = DateTime.Now,
            Details = new List<ExtractionDetail>()
        };

        await _extractionPerformed.Add(extractionPerformed);

        foreach (var url in documentRequest.urlDocument)
        {
            var detail = new ExtractionDetail
            {
                Id = Guid.NewGuid(),
                NameDocument = url,
                ExtractionPerformedId = extractionPerformed.Id
            };

            extractionPerformed.Details.Add(detail);
        }

        await _extractionPerformed.AddRange(extractionPerformed.Details);
    }
}
