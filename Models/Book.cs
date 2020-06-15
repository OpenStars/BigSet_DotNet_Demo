
using Newtonsoft.Json;
namespace BooksApi.Models
{
    public class Book
    {
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}