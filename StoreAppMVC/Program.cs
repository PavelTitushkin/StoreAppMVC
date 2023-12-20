using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StoreApp_Bussines.Services;
using StoreApp_Core.Contracts;
using StoreApp_Core.DTOs;
using StoreApp_Core.ModelConfig;
using StoreApp_Data_CQS.Commands.Order;
using StoreApp_Data_CQS.Commands.OrderItems;
using StoreApp_Data_CQS.Commands.Provider;
using StoreApp_Data_CQS.Handlers.CommandHandlers.OrderItems;
using StoreApp_Data_CQS.Handlers.CommandHandlers.Orders;
using StoreApp_Data_CQS.Handlers.CommandHandlers.Providers;
using StoreApp_Data_CQS.Handlers.QueryHandlers.OrderItems;
using StoreApp_Data_CQS.Handlers.QueryHandlers.Orders;
using StoreApp_Data_CQS.Handlers.QueryHandlers.Providers;
using StoreApp_Data_CQS.Queries.OrderItems;
using StoreApp_Data_CQS.Queries.Orders;
using StoreApp_Data_CQS.Queries.Providers;
using StoreApp_DataBase;
using StoreAppMVC.Filters;
using StoreAppMVC.Middlewares;
using System.Reflection;
using WebAppMedicalAssistantMVC.Infrastructure;

namespace StoreAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Serilog
            builder.Host.UseSerilog((context, ñonfig) =>
              ñonfig.ReadFrom.Configuration(context.Configuration));

            // Add services to the container.
            builder.Services.AddControllersWithViews(opts =>
            {
                opts.ModelBinderProviders.Insert(0, new CustomDateTimeModelBinderProvider());
                opts.Filters.Add(typeof(AppExceptionFilter));
            });

            //Add AppSettings
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("SearchMonth"));

            //Add DbContext
            var connectionString = builder.Configuration.GetConnectionString("StoreAppDatabase");
            builder.Services.AddDbContext<StoreAppContext>(options => options.UseSqlServer(connectionString));

            //AddMediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //AddAutomapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //AddServices
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IProviderService, ProviderService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();

            builder.Services.AddScoped<StoreAppContext>();
            builder.Services.AddScoped<IRequestHandler<CreateOrderCommand, bool>, CreateOrderCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<GetOrderItemsByFilterQuery, ICollection<OrderItemDTO>?>, GetOrderItemsByFilterQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<GetAllProvidersQuery, ICollection<ProviderDTO>>, GetAllProvidersQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<EditOrderCommand, Unit>, EditOrderCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeleteOrderCommand, Unit>, DeleteOrderCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<GetOrdersByFilterQuery, ICollection<OrderDTO>?>, GetOrdersByFilterQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateOrderItemCommand, Unit>, CreateOrderItemCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<GetOrderByIdQuery, OrderDTO?>, GetOrderByIdQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<EditOrderItemCommand, Unit>, EditOrderItemCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeleteOrderItemCommand, Unit>, DeleteOrderItemCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<IsExistOrderNameQuery, bool>, IsExistOrderNameQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateProviderCommand, Unit>, CreateProviderCommandHandler>();

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

            //Add logging middleware
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.Run();
        }
    }
}