using GameRoulette.Repositories;
using GameRoulette.DTO_s;   

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IKnifeRepository, KnifeRepository>();

var app = builder.Build();
//Generating knifes
var random = new Random();
var knifes = new List<KnifeDto>();
for (int i = 0; i < 10; i++)
{
    knifes.Add(new KnifeDto(id: i, name: $"SomeKnife #{i}", exterior: "Factory New", price: random.Next(1000, 10000)));
}


//Here we creates an endpoint, in our case GET 'localhost:5000/knife'
//That returns a list of knifes that we generated earlier
app.MapGet("/knife", () => 
{
    return knifes;
});

app.MapGet("/knife/{id}", (int id) =>
{
    return knifes.FirstOrDefault(x => x.Id == id);
});

//So the task is to implement new endpoint for buying those knifes
//Basically we pass an id of a knife we want to buy, and method should returns true if it success or false if it's not
//Example of a request POST 'localhost:5000/knife/1/1234'
app.MapPost("/knife/{id}/buy/{price}", (int id, int price) => 
{
    var knife = knifes.FirstOrDefault(x => x.Id == id);
    if (knife == null || knife.Price > price)
    {
        return false;
    }
    knifes.Remove(knife);
    return true;
});
app.MapPost("/knife/", (AddKnifeRequestDto myknife) =>
{
    int id = new List<KnifeDto>().Last().Id + 1;
    knifes.Add(new KnifeDto(id: id, myknife.Name, exterior: myknife.Exterior, price: myknife.Price));
});
app.MapPost("/knife/roulette", () =>
{
    //logic
    var randomFirst = knifes.ElementAt(random.Next(knifes.Count - 1));
    knifes.Remove(randomFirst);
    return randomFirst;
});
app.UseSwagger();
app.UseSwaggerUI();
app.Run();