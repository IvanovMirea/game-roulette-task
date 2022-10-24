using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameRoulette.DTO_s;
using GameRoulette.Repositories;


namespace GameRoulette.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class KnifeController : ControllerBase
    {
        private readonly IKnifeRepository _knifeRep;

        public KnifeController(IKnifeRepository knifeRep)
        {
            _knifeRep = knifeRep;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            KnifeDto knife = _knifeRep.Get(id);
            if (knife == null)
            {
                return NotFound();
            }
            return Ok(knife);
        }

        [HttpPost]
        public ActionResult<KnifeDto> Roulette()
        {
            KnifeDto knife = _knifeRep.GetRandom();
            _knifeRep.Delete(knife);
            return Ok(knife);

        }

        [HttpGet]
        public ActionResult<List<KnifeDto>> GetAll() => _knifeRep.GetAll();

        [HttpPost]
        public ActionResult<KnifeDto> Add(AddKnifeRequestDto request) => _knifeRep.Add(request);

        [HttpPost("{id}/buy/{price}")]
        public ActionResult Buy(int id, int price)
        {
            KnifeDto knife = _knifeRep.Get(id);
            if (knife == null || knife.Price > price)
            {
                return NotFound();
            }
            _knifeRep.Delete(knife);
            return Ok();
        }
    }
}
