using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories;
using BookLibrary.Domain.Search;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Book>> SearchAsync([FromQuery] BookSearch search)
            => _bookRepository.GetAllAsync(search);
    }
}
