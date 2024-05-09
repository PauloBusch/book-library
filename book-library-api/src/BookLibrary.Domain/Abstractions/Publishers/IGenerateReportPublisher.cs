using BookLibrary.Shared.Messages;

namespace BookLibrary.Domain.Abstractions.Publishers
{
    public interface IGenerateReportPublisher
    {
        Task GenerateBookReportAsync(BookReportMessage message);
    }
}
