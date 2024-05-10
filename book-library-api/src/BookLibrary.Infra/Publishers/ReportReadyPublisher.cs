using BookLibrary.Domain.Abstractions.Publishers;
using BookLibrary.Shared.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Infra.Publishers
{
    public class ReportReadyPublisher : IReportReadyPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<ReportReadyPublisher> _logger;

        public ReportReadyPublisher(
            IPublishEndpoint publishEndpoint,
            ILogger<ReportReadyPublisher> logger
        )
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task BookReportReadyAsync(ReportReadyMessage message)
        {
            _logger.LogInformation("Notifying report conclusion.");
            await _publishEndpoint.Publish(message);
        }
    }
}
