using BookLibrary.Shared.Messages;

namespace BookLibrary.Domain.Abstractions.Publishers
{
    public interface IReportReadyPublisher
    {
        Task BookReportReadyAsync(ReportReadyMessage message);
    }
}
