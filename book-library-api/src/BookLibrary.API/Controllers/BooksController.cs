using BookLibrary.Domain.Abstractions.Publishers;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Domain.Models;
using BookLibrary.Shared.Messages;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenerateReportPublisher _generateReportPublisher;

        public BooksController(
            IBookRepository bookRepository,
            IGenerateReportPublisher generateReportPublisher
        )
        {
            _bookRepository = bookRepository;
            _generateReportPublisher = generateReportPublisher;
        }

        [HttpGet]
        public Task<IEnumerable<Book>> SearchAsync([FromQuery] BookSearch search)
            => _bookRepository.GetAllAsync(search);

        [HttpGet("report")]
        public Task SearchAsync([FromQuery] BookReportMessage message)
            => _generateReportPublisher.GenerateBookReportAsync(message);
    }
}
