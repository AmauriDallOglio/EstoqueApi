using EstoqueApi.Aplicacao.Negocio.Categoria.Command;
using EstoqueApi.Aplicacao.Negocio.Categoria.Handler;
using EstoqueApi.Aplicacao.Negocio.Categoria.Query;
using EstoqueApi.Aplicacao.Negocio.Produto.Handler;
using EstoqueApi.Aplicacao.Negocio.Produto.Query;
using EstoqueApi.Dominio.Entidade;
using EstoqueApi.Infra.Context;
using EstoqueApi.Infra.Repositorio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder()
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.Development.json")
	.Build();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
				opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

 

builder.Services.AddTransient<IRequestHandler<CreateCategoryCommand, bool>, CreateCategoryCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllCategoriesQuery, IEnumerable<Categoria>>, GetAllCategoryQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllProductQuery, IEnumerable<Produto>>, GetAllProductQueryHandler>();



builder.Services.AddDbContextPool<DbContext, MeuContext>(options =>
{
	options.UseSqlServer(configuration.GetConnectionString("sql_connection"));
});
builder.Services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));


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


app.MapControllers();

app.Run();
