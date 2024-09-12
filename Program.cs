using Microsoft.EntityFrameworkCore;
using PokedexApi.ApiSettings;
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
            builder
                .WithOrigins("http://localhost", "http://localhost:5000", "http://localhost:3000", "https://dolmi.sodomann.dev")
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

// Use API Key middleware
app.UseMiddleware<ApiKeyMiddleware>();

// Add these lines to serve static files
app.UseDefaultFiles();
app.UseStaticFiles();

//Allow Svlet
app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();

