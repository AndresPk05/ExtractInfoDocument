using Azure.AI.DocumentIntelligence;
using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;

namespace ExtractInfoDocument.BUISNESS_LOGIC.LOGIC;

public class Document : IDocument
{
    public DTOS.Document TransformDataAzure(AnalyzedDocument analyzedDocument)
    {
        var document = new DTOS.Document();
        var type = typeof(DTOS.Document);
        var attributes = type.GetProperties();
        var typePerson = typeof(DTOS.Person);
        var attributesPerson = typePerson.GetProperties();
        var typeDetail = typeof(DTOS.Detail);
        var attributesDetail = typeDetail.GetProperties();
        var sender = new DTOS.Person();
        var recipient = new DTOS.Person();

        document = getObjectDocument(analyzedDocument, CONSTANTS.Document.FieldsDocument, document, attributes);
        sender = getObjectDocument(analyzedDocument, CONSTANTS.Document.FieldsSender, sender, attributesPerson);
        recipient = getObjectDocument(analyzedDocument, CONSTANTS.Document.FieldsRecipient, recipient, attributesPerson);
        document.Sender = sender;
        document.Recipient = recipient;
        document.Details = getDetails(analyzedDocument.Fields.FirstOrDefault(x => x.Key == "Items").Value);

        return document;
    }

    private List<Detail> getDetails(DocumentField fieldItems)
    {
        var details = new List<Detail>();
        var type = typeof(DTOS.Detail);
        var attributes = type.GetProperties();

        foreach (var field in fieldItems.ValueArray)
        {
            var detail = new Detail();
            detail = getObjectDocument(field, CONSTANTS.Document.FieldsDetail, detail, attributes);
            details.Add(detail);
        }

        return details;
    }

    private T getObjectDocument<T>(
        AnalyzedDocument analyzedDocument,
        Dictionary<string, string> Fields,
        T Object,
        System.Reflection.PropertyInfo[] properties)
    {
        foreach (var property in properties)
        {
            var field = Fields.FirstOrDefault(x => x.Value == property.Name);
            if (field.Key is null) continue;
            var fieldDocument = analyzedDocument.Fields.FirstOrDefault(x => x.Key == field.Key);
            if (fieldDocument.Key is null) continue;
            property.SetValue(Object, fieldDocument.Value.Content);
        }

        return Object;
    }

    private T getObjectDocument<T>(
    DocumentField fieldDetail,
    Dictionary<string, string> Fields,
    T Object,
    System.Reflection.PropertyInfo[] properties)
    {
        foreach (var property in properties)
        {
            var field = Fields.FirstOrDefault(x => x.Value == property.Name);
            if (field.Key is null) continue;
            var fieldDocument = fieldDetail.ValueObject.FirstOrDefault(x => x.Key == field.Key);
            if (fieldDocument.Key is null) continue;
            property.SetValue(Object, fieldDocument.Value.Content);
        }

        return Object;
    }
}
