//using Microsoft.Extensions.Configuration;

using ConsumeAPIExample.Models.ApiInternal;
using ConsumeAPIExample.Services.ApiInternalService.OrganizerServices;
using ConsumeAPIExample.Services.ApiInternalService.UserServices;
using ConsumeAPIExample.Utilities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ConsumeAPIExample
{
	public class Program
	{

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			ConfigurationManager configuration = builder.Configuration;

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.Configure<VoxApi>(configuration.GetSection(ApplicationConstant.ApiSection.VOX_API));
			builder.Services.AddHttpClient<IOrganizerService, OrganizerService>();
			builder.Services.AddHttpClient<IUserService, UserService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}

	}
}