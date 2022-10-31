using Microsoft.AspNetCore.Mvc;
using GameRoulette.Dto;
using GameRoulette.Repositories;


namespace GameRoulette.Controllers;

[Route("api/[controller]")]
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

    [HttpPost("/api/knife/random")]
    public ActionResult<KnifeDto> Roulette()
    {
        KnifeDto knife = _knifeRep.GetRandom();
        _knifeRep.Delete(knife);    
        return Ok(knife);

    }

    [HttpGet]
    public ActionResult<List<KnifeDto>> GetAll()
    {
        return Ok(_knifeRep.GetAll());
    } 

    [HttpPost]
    public ActionResult<KnifeDto> Add(AddKnifeRequestDto request) => _knifeRep.Add(request);

    [HttpPost("{id}/buy/{price}")]
    public ActionResult Buy(int id, int price)
    {
        KnifeDto? knife = _knifeRep.Get(id);
        if (knife == null)
        {
            return NotFound();
        }
        _knifeRep.Delete(knife);
        return Ok();
    }
}
