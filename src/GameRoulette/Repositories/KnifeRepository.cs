using GameRoulette.Dto;

namespace GameRoulette.Repositories
{
    public class KnifeRepository : IKnifeRepository
    {
        private readonly List<KnifeDto> _knifes = new();
        public KnifeDto Add(AddKnifeRequestDto myKnife)
        {
            Random random = new Random();
            var id = 0;
            var newKnife = new KnifeDto(id: id, myKnife.Name, exterior: myKnife.Exterior, price: myKnife.Price);
            if (_knifes.Count == 0)
            {
                _knifes.Add(newKnife);
                return newKnife;
            }
            var newInf = _knifes.Last().Id + 1;
            var newKnifes = new KnifeDto(id: newInf, myKnife.Name, exterior: myKnife.Exterior, price: myKnife.Price);
            _knifes.Add(newKnifes);
            return newKnifes;
            
        }

        public void Delete(KnifeDto knife)
        {
            _knifes.Remove(knife);
            if (_knifes.Contains(knife) == false)
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
