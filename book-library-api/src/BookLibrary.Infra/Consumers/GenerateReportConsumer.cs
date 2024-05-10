using BookLibrary.Domain.Abstractions.Services;
using BookLibrary.Shared.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Infra.Consumers
{
    public class GenerateReportConsumer : IConsumer<BookReportMessage>
    {
        private readonly IReportService _reportService;
        private readonly ILogger<GenerateReportConsumer> _logger;

        public GenerateReportConsumer(
            IReportService reportService,
            ILogger<GenerateReportConsumer> logger
        )
        {
            _reportService = reportService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BookReportMessage> context)
        {
            _logger.LogInformation("Message consumed to generate report.");
            await _reportService.GenerateReportAsync(context.Message);
        }
    }
}
