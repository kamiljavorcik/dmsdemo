namespace Database.Models
{
    public class Document
    {
        public Document()
        {
            Tags = new List<string>();
            Data = new Dictionary<string, string>();
        }

        public string Id { get; set; }
        public IList<string> Tags { get; set; }
        public IDictionary<string,string> Data { get; set; }
    }
}
