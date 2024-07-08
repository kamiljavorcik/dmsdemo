namespace Repository.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Data> Datas { get; set; }
    }
}
