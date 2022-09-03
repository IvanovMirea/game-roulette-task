var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapPost("/knife/{id}/buy/{price}", (int id, int price) => {
    var knife = knifes.FirstOrDefault(x => x.Id == id);
    if (knife == null || knife.Price > price)
    {
        return false;
    }
    knifes.Remove(knife);
    return true;
});

//The second task is to implement adding of new knife
//The endpoint should look like POST 'localhost:5000/knife/'
app.MapPost("/knife/sell/{name}/{exterior}/{price}",(string name, string exterior, int price) =>
{
    int idCount = knifes[knifes.Count-1].Id;
    int id = idCount+1;
    knifes.Add(new KnifeDto(id: id, name: name, exterior: exterior, price: price));
});
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

public class KnifeDto
{
    public KnifeDto(int id, string name, string exterior, int price)
    {
        Id = id;
        Name = name;
        Exterior = exterior;
        Price = price;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Exterior { get; set; }
    public int Price { get; set; }
}