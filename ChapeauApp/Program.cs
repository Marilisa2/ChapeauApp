using ChapeauApp.Repositories;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IOrdersService, OrdersService>();
            builder.Services.AddSingleton<IVatsService, VatsService>();
            builder.Services.AddSingleton<IPaymentMethodsService, PaymentMethodsService>();

            builder.Services.AddControllersWithViews();

            //Repository

            //DatbaseRepository
            builder.Services.AddSingleton<IOrdersRepository, DbOrdersRepository>();
            builder.Services.AddSingleton<IOrderItemsRepository, DbOrderItemsRepository>();
            builder.Services.AddSingleton<ITablesRepository, DbTablesRepository>();
            builder.Services.AddSingleton<IBillsRepository, DbBillsRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
