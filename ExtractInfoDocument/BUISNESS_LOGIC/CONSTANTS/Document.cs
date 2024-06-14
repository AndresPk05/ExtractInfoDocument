namespace ExtractInfoDocument.BUISNESS_LOGIC.CONSTANTS
{
    public static class Document
    {
        public const string Invoice = "prebuilt-invoice";
        public static Dictionary<string, string> FieldsDocument = new Dictionary<string, string>
        {
            { "InvoiceDate", "Date" },
            { "CustomerAddress", "Address" },
            { "InvoiceTotal", "Total" },
            { "TotalTax", "TotalTax" },
            { "SubTotal", "SubTotal" },
        };

        public static Dictionary<string, string> FieldsSender = new Dictionary<string, string>
        {
            { "VendorName", "Name" },
            { "VendorTaxId", "Identification" }
        };

        public static Dictionary<string, string> FieldsRecipient = new Dictionary<string, string>
        {
            { "CustomerName", "Name" },
            { "CustomerTaxId", "Identification" }
        };

        public static Dictionary<string, string> FieldsDetail = new Dictionary<string, string>
        {
            { "Description", "NameProduct" },
            { "Quantity", "Quantity" },
            { "UnitPrice", "UnitPrice" },
            { "Tax", "Tax" }
        };
    }
}
