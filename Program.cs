using libreria;
using libreria.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<LibreriaContext>("Data Source=localhost; Initial Catalog=libreriaDB;user id=sa;password=Programaci0n$;Encrypt=False");
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<ILibroService, LibroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //Documentacion del REST API
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
