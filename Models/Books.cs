using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge18June.Models
{
    public class Books
    {
        [Key]
        public int ISBN { get; set; }
        public string Title {  get; set; }

        public string Author { get; set; }
        public string Genre { get; set; }
        public string PublicationYear { get; set; }
        public string Publisher { get; set; }
        public int TotalCopies { get; set; }
        public Books()
        {
            
        }

        public Books(int iSBN, string title, string author, string genre, string publicationYear, string publisher, int totalCopies)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
            Genre = genre;
            PublicationYear = publicationYear;
            Publisher = publisher;
            TotalCopies = totalCopies;
        }
    }
}
