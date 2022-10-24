using GameRoulette.DTO_s;

namespace GameRoulette.Repositories
{
    public class KnifeRepository : IKnifeRepository
    {
        private readonly List<KnifeDto> _knifes = new();
        public KnifeDto Add(AddKnifeRequestDto myKnife)
        {
            var id = _knifes.Last().Id + 1;
            var newKnife = new KnifeDto(id: id, myKnife.Name, exterior: myKnife.Exterior, price: myKnife.Price);
            _knifes.Add(newKnife);
            return newKnife;
        }

        public void Delete(KnifeDto knife)
        {
            var knifes = new List<KnifeDto>();
            knifes.Remove(knife);
            if (knifes.Contains(knife) == false)
            {
                return;
            }
            return;
        }

        public KnifeDto Get(int id)
        {
            return _knifes.FirstOrDefault(x => x.Id == id);
        }

        public List<KnifeDto> GetAll()
        {
            return _knifes;
        }

        public KnifeDto GetRandom()
        {
            return _knifes.ElementAt(new Random().Next(_knifes.Count - 1));
        }
    }
}
