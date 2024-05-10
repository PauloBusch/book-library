using BookLibrary.Shared.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Infra.Consumers
{
    public class ReportReadyConsumer : IConsumer<ReportReadyMessage>
    {
        private readonly ILogger<ReportReadyConsumer> _logger;

        public ReportReadyConsumer(ILogger<ReportReadyConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ReportReadyMessage> context)
        {
            _logger.LogInformation("Message consumed after report generation.");
            _logger.LogInformation("ReportId: {0}", context.Message.ReportId);
        }
    }
}
