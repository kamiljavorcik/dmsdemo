namespace Database.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public Document Document { get; set; }
    }
}
