namespace CatalogApp.Models
{
    public class Book
    {
        public int Id  {get; set;}
        public string Name { get; set; } = null!;
        public int Pages { get; set; }
        public string Author { get; set; } = null!;
        public string? ImageUrl  {get; set;}
        public double Price  {get; set;}
        public int InStock  {get; set;}
    }
}