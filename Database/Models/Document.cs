namespace Database.Models
{
    public class Document
    {
        public Document()
        {
            Tags = new List<Tag>();
            Datas = new List<Data>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Data> Datas { get; set; }
    }
}
