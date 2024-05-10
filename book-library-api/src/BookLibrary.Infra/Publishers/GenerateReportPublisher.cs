using BookLibrary.Domain.Abstractions.Publishers;
using BookLibrary.Shared.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Infra.Publishers
{
    public class GenerateReportPublisher : IGenerateReportPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<GenerateReportPublisher> _logger;

        public GenerateReportPublisher(
            IPublishEndpoint publishEndpoint,
            ILogger<GenerateReportPublisher> logger
        )
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task GenerateBookReportAsync(BookReportMessage message)
        {
            _logger.LogInformation("Sending message to generate report!");
            await _publishEndpoint.Publish(message);
        }
    }
}
