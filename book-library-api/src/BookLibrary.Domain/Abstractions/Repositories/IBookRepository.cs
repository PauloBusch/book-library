using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models;

namespace BookLibrary.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync(BookSearch search);
    }
}
