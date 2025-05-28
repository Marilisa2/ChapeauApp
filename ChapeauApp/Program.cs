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
            //Services
            builder.Services.AddSingleton<ILoginOrOffService, LoginOrOffService>();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            builder.Services.AddSingleton<ITableService, TableService>();
            builder.Services.AddSingleton<IMenusService, MenusService>();
            builder.Services.AddSingleton<IOrderItemsService, OrderItemsService>();
            builder.Services.AddSingleton<IOrdersService, OrdersService>();
            builder.Services.AddSingleton<IVatsService, VatsService>();
            builder.Services.AddSingleton<IPaymentMethodsService, PaymentMethodsService>();

            builder.Services.AddControllersWithViews();

            //DatbaseRepository
            builder.Services.AddSingleton<IEmployeeRepository, DbEmployeesRepository>();
            builder.Services.AddSingleton<ITableRepository, DbTablesRepository>();
            builder.Services.AddSingleton<IMenusRepository, DbMenusRepository>();
            builder.Services.AddSingleton<IOrderItemsRepository, DbOrderItemsRepository>();
            builder.Services.AddSingleton<IOrdersRepository, DbOrdersRepository>();
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
