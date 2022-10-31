namespace GameRoulette.Dto;

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
