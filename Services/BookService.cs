using CodingChallenge18June.Exceptions;
using CodingChallenge18June.Interfaces;
using CodingChallenge18June.Models;

namespace CodingChallenge18June.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<int, Books> _repository;

        public BookService(IRepository<int, Books> repository)
        {
            _repository = repository;

        }
        public async  Task<Books> AddBook(Books book)
        {
            book = await _repository.Add(book);
            return book;
        }

        public async  Task<List<Books>> GetAllBooks()
        {
            var books = await _repository.GetAsync();
            return books;
        }

        public async Task<Books> GetBook(int ISBN)
        {
            var book = await _repository.GetAsync(ISBN);
            return book;
        }

        public async  Task<Books> RemoveBook(int ISBN)
        {
            var book = await GetBook(ISBN);
            if (book != null)
            {
               book = await _repository.Delete(ISBN);
                return book;
            }
            throw new NoSuchBookException();
        }
        public async Task<Books> UpdateBook(Books book)
        {
            var books = await _repository.GetAsync(book.ISBN);
            if (books != null)
            {
                books.Title = book.Title;
                books.Author = book.Author;
                books.Genre = book.Genre;
                books.PublicationYear = book.PublicationYear;
                books.Publisher = book.Publisher;
                books.TotalCopies = book.TotalCopies;
                return await _repository.Update(books);
            }
            throw new NoSuchBookException();
        }

    }

      
    
}
