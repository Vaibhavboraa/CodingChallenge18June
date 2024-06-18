using CodingChallenge18June.Exceptions;
using CodingChallenge18June.Interfaces;
using CodingChallenge18June.Models;
using CodingChallenge18June.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CodingChallenge18June.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookServive;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookServive= bookService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<List<Books>> GetBooks()
        {
            var book = await _bookServive.GetAllBooks();
            return book;
        }

      
        [Route("/GetBookById")]
        [HttpGet]
        public async Task<Books> GetBookById(int ISBN)
        {
            var book = await _bookServive.GetBook(ISBN);
            return book;
        }
        [HttpDelete]
      
        public async Task<Books> DeleteBook(int ISBN)
        {
            var book = await _bookServive.RemoveBook(ISBN);
            return book;
        }
        [HttpPost]
       
        public async Task<Books> PostBook(Books book)
        {
            book = await _bookServive.AddBook(book);
            return book;
        }
        [HttpPut("{ISBN}")]
        public async Task<ActionResult<Books>> UpdateBook(int ISBN, Books book)
        {
            if (ISBN != book.ISBN)
            {
                return BadRequest("ISBN mismatch");
            }

            try
            {
                var updatedBook = await _bookServive.UpdateBook(book);
                if (updatedBook == null)
                {
                    return NotFound();
                }
                return Ok(updatedBook);
            }
            catch (NoSuchBookException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating book: {ex.Message}");
                return BadRequest("Unable to update book");
            }
        }


    }
}
