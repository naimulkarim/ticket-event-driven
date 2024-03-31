using MassTransit;

namespace TicketService
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost:5672");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            //var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            //{
            //    config.Host("amqp://guest:guest@localhost:5672");
            //    //config.ReceiveEndpoint("test-queue", m =>
            //    //{
            //    //    m.Handler<Purchase>()
            //    //})
            //});
        }


    }
}
