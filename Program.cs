using Microsoft.EntityFrameworkCore;
using PokedexApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Allow Svlet
builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


//Database
builder.Services.AddDbContext<DataContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("PokemonDB"))
);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Allow Svlet
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

