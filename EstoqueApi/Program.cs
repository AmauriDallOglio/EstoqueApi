using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
				opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContextPool<DbContext, PrateleiraDbContext>(options =>
{
	options.UseSqlServer(configuration.GetConnectionString("sql_connection"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Minha.API",
		Description = "API CRUD",
		TermsOfService = new Uri("https://example.com/terms"),
		Contact = new OpenApiContact
		{
			Name = "Amauri",
			Email = "amauri@hotmail.com",
			Url = new Uri("https://github.com/amauridalloglio"),
		},
		License = new OpenApiLicense
		{
			Name = "User",
			Url = new Uri("https://example.com/license"),
		}
	});
});



var app = builder.Build();


app.UseDeveloperExceptionPage();


app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API");
	c.RoutePrefix = string.Empty;
});

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	endpoints.MapGet("/", async context =>
	{
		await context.Response.WriteAsync("Hello World!");
	});
});

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
