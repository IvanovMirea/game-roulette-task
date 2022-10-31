namespace GameRoulette.DTO_s
{
    public class AddKnifeRequestDto
    {
        Random random = new Random();
        public AddKnifeRequestDto(string name, string exterior, int price)
        {
            Name = name;
            Exterior = exterior;
            Price = price;
            Price = random.Next(1000, 10000);
        }
        public string Name { get; set; }
        public string Exterior { get; set; }
        public int Price { get; set; }
    }
}
