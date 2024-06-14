namespace ExtractInfoDocument.BUISNESS_LOGIC.DTOS
{
    public class Result<T> where T : class
    {
        public bool Error { get; set; }
        public T Value { get; set; }
        public string Message { get; set; }
    }
}
