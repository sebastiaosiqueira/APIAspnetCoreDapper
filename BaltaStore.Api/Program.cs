using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.DataContexts;
using BaltaStore.Infra.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using BaltaStore.Shared;



internal class Program
{
    public static IConfiguration Configuration{ get; set; }
    private static void Main(string[] args, WebApplicationBuilder configurationBuilder)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddResponseCompression();
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

        builder.Services.AddScoped<BaltaDataContext, BaltaDataContext>();
        builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
        builder.Services.AddTransient<IEmailService, EmailService>();
        builder.Services.AddTransient<CustomerHandler, CustomerHandler>();
        Settings.ConnectionString = $"{Configuration["connectionString"]}";
        builder.Services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "BaltaStore", Version = "v1" });
        });
      

        builder.Services.AddElmahIo(options =>
        {
            options.ApiKey = "apikey";
            options.LogId = new Guid("Logid");
        });


        var app = builder.Build();
        app.MapGet("/", () => "Olá do Minimal API!");
        app.MapControllers();
        app.MapControllerRoute(name: "default",
                                pattern: "{controller=Home}");

        app.UseResponseCompression();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaltaStore - v1");
        });


        app.UseElmahIo();
        app.Run();
    }
}