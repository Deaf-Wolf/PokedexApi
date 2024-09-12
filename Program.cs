using Microsoft.EntityFrameworkCore;
using PokedexApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

// Add this section to check for missing Pok�mon
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();

    var pokemons = await context.Pokemons.OrderBy(p => p.PokedexNumber).ToListAsync();
    Console.WriteLine($"Total Pok�mon: {pokemons.Count}");

    var missingPokemons = new List<int>();
    int expectedPokedexNumber = 1;

    foreach (var pokemon in pokemons)
    {
        while (pokemon.PokedexNumber > expectedPokedexNumber)
        {
            missingPokemons.Add(expectedPokedexNumber);
            expectedPokedexNumber++;
        }
        expectedPokedexNumber = pokemon.PokedexNumber + 1;
    }

    if (missingPokemons.Count != 0)
    {
        Console.WriteLine($"Missing Pok�mon: {string.Join(", ", missingPokemons)}");
    }
    else
    {
        Console.WriteLine("No missing Pok�mon found.");
    }
}
