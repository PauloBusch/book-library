using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories;
using BookLibrary.Domain.Search;
using Dapper;
using System.Data;

namespace BookLibrary.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _connection;

        public BookRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Book>> GetAllAsync(BookSearch search)
        {
            var sql = $@"
                SELECT 
                    book_id as id, title, first_name, last_name, type, isbn, category,
                    total_copies, copies_in_use
                FROM books
                WHERE 1=1
                {(!string.IsNullOrWhiteSpace(search.Title) ? "AND title like '%' + @Title + '%'" : string.Empty)}
                {(!string.IsNullOrWhiteSpace(search.Author) ? "AND (first_name like @Author + '%' OR last_name like @Author + '%')" : string.Empty)}
                {(!string.IsNullOrWhiteSpace(search.Isbn) ? "AND isbn like '%' + @Isbn + '%'" : string.Empty)}
                {(!string.IsNullOrWhiteSpace(search.Category) ? "AND category like @Category + '%'" : string.Empty)}
                ORDER BY title ASC
                OFFSET 0 ROWS
                FETCH NEXT {search.Take} ROWS ONLY;
            ";

            return await _connection.QueryAsync<Book>(sql, search);
        }
    }
}
