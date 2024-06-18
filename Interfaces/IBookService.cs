using CodingChallenge18June.Models;

namespace CodingChallenge18June.Interfaces
{
    public interface IBookService
    {
        Task<Books> AddBook(Books book);
        Task<List<Books>> GetAllBooks();
        Task<Books> GetBook(int ISBN);
        Task<Books> RemoveBook(int ISBN);
        Task<Books> UpdateBook(Books book);
    }
}
