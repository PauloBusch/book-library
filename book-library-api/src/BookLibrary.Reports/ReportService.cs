using BookLibrary.Domain.Abstractions.Publishers;
using BookLibrary.Domain.Abstractions.Services;
using BookLibrary.Shared.Messages;
using System.Text.Json;

namespace BookLibrary.Reports
{
    public class ReportService : IReportService
    {
        private readonly ILogger<ReportService> _logger;
        private readonly IReportReadyPublisher _publisher;

        public ReportService(
            ILogger<ReportService> logger,
            IReportReadyPublisher publisher
        )
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task GenerateReportAsync(BookReportMessage message)
        {
            _logger.LogInformation("Begin to process the report.");

            // TODO: Some heavy workload could be implemented here to generate the report asynchronously
            await Task.Delay(1000);
            var reportId = Guid.NewGuid();

            _logger.LogInformation("The report generation was ended, ReportId: {0}.", reportId);
            await _publisher.BookReportReadyAsync(new ReportReadyMessage { ReportId = reportId });
        }
    }
}
