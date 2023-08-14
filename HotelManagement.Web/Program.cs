using FluentValidation.AspNetCore;
using HotelManagement.Domain;
using HotelManagement.Entities;
using HotelManagement.Operations;
using Microsoft.EntityFrameworkCore;

namespace Api.Hotel.Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HotelManagementDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:HotelManagementDbContext"));

            //Register project services
            OperationsServices.Add(builder.Services);
            DomainServices.Add(builder.Services);

            builder.Services.AddScoped<IHotelManagementDbContext, HotelManagementDbContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}