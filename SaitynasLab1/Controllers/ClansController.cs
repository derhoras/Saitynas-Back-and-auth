using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Repositories;
using SaitynasLab1.Data.Entities;
using SaitynasLab1.Data.Dtos.Clans;
using AutoMapper;

namespace SaitynasLab1.Controllers
{
    /*
    /api/clans GET ALL 200
    /api/clans/{id} GET 200
    /api/clans POST 201
    /api/clans/{id} PUT 200/201
    /api/clans/{id} 200/204
    */

    [ApiController]
    [Route("api/clans")]
    public class ClansController : ControllerBase
    {
        private readonly IClansRepository _clansRepository;
        private readonly IMapper _mapper;
        public ClansController(IClansRepository clansRepository, IMapper mapper)
        {
            _clansRepository = clansRepository;
            _mapper = mapper;
        }

       

        [HttpGet]
        public async Task<IEnumerable<ClanDto>> GetAll()
        {
            return (await _clansRepository.GetAll()).Select(o => _mapper.Map<ClanDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClanDto>> Get(int id)
        {
            var clan = await _clansRepository.Get(id);
            if (clan == null) return NotFound($"Clan with id '{id}' not found.");

            return Ok(_mapper.Map<ClanDto>(clan));
        }

       
        [HttpPost]
        public async Task<ActionResult<ClanDto>>Post(CreateClanDto clanDto)
        {
            var clan = _mapper.Map<Clan>(clanDto);

            await _clansRepository.Create(clan);

            //201
            return Created($"/api/clans/{clan.Id}", _mapper.Map<ClanDto>(clan));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClanDto>> Put(int id, UpdateClanDto clanDto)
        {
            var clan = await _clansRepository.Get(id);
            if (clan == null) return NotFound($"Clan with id '{id}' not found.");

            //clan.Name = clanDto.Name;
            _mapper.Map(clanDto, clan);

            await _clansRepository.Put(clan);

            return Ok(_mapper.Map<ClanDto>(clan));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClanDto>> Delete(int id)
        {
            var clan = await _clansRepository.Get(id);
            if (clan == null) return NotFound($"Clan with id '{id}' not found.");


            await _clansRepository.Delete(clan);

            //204
            return NoContent();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
