namespace GameRoulette.Dto;

public class AddKnifeRequestDto
{

    public AddKnifeRequestDto(string name, string exterior, int price)
    {
        Name = name;
        Exterior = exterior;
        Price = price;
    }
    public string Name { get; set; }
    public string Exterior { get; set; }
    public int Price { get; set; }
}
