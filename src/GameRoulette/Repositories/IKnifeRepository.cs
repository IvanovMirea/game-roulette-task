using GameRoulette.DTO_s;

namespace GameRoulette.Repositories
{
    public interface IKnifeRepository
    {
        List<KnifeDto> GetAll();
        KnifeDto Get(int id);

        void Delete(KnifeDto knife);

        KnifeDto Add(AddKnifeRequestDto myKnife);

        KnifeDto GetRandom();


    }
}
