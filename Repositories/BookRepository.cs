using CodingChallenge18June.Contexts;
using CodingChallenge18June.Exceptions;
using CodingChallenge18June.Interfaces;
using CodingChallenge18June.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge18June.Repositories
{
    public class BookRepository : IRepository<int, Books>
    {
        private readonly BookContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(BookContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async  Task<Books> Add(Books item)
        {
            _context.Add(item);
            _context.SaveChanges();
            _logger.LogInformation("Book added " + item.ISBN);
            return item;
        }

        public async Task<Books> Delete(int key)
        {
            var book = await GetAsync(key);
            _context?.Books.Remove(book);
            _context?.SaveChanges();
            _logger.LogInformation("Book deleted " + key);
            return book;
        }

        public async Task<Books> GetAsync(int key)
        {
            var books = await GetAsync();
            var book = books.FirstOrDefault(e => e.ISBN == key);
            if (book != null)
            {
                return book;
            }
            throw new NoSuchBookException();
        }

        public async Task<List<Books>> GetAsync()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public async Task<Books> Update(Books item)
        {
            var book = await GetAsync(item.ISBN);
            _context.Entry<Books>(item).State = EntityState.Modified;
            _context.SaveChanges();
            _logger.LogInformation("Book updated " + item.ISBN);
            return book;
        }
    }
}
