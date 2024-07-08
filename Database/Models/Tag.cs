namespace Database.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Document Document { get; set; }
    }
}
