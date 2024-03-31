using MassTransit;
using System.Text.Json;
using TicketService.Model;

namespace StockService
{
    public class PurchaseConsumner : IConsumer<Purchase>
    {
        private readonly ILogger<PurchaseConsumner> logger;

        public PurchaseConsumner(ILogger<PurchaseConsumner> logger)
        {
            this.logger = logger;
        }
        public async Task Consume(ConsumeContext<Purchase> context)
        {
            var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });
            await Console.Out.WriteLineAsync(serializedMessage);
            logger.LogInformation($"Got new message {context.Message}");
        }
    }
}
