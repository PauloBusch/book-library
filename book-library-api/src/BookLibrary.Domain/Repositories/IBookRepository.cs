using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Search;

namespace BookLibrary.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync(BookSearch search);
    }
}
