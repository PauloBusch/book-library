using BookLibrary.Shared.Messages;

namespace BookLibrary.Domain.Abstractions.Services
{
    public interface IReportService
    {
        Task GenerateReportAsync(BookReportMessage message);
    }
}
