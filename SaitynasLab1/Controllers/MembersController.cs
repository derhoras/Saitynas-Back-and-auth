using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Repositories;
using SaitynasLab1.Data.Entities;
using SaitynasLab1.Data.Dtos.Members;
using AutoMapper;

namespace SaitynasLab1.Controllers
{
    [ApiController]
    [Route("api/clans/{clanId}/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;
        private readonly IClansRepository _clansRepository;

        public MembersController(IMembersRepository membersRepository,IMapper mapper, IClansRepository clansRepository)
        {
            _membersRepository = membersRepository;
            _mapper = mapper;
            _clansRepository = clansRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MemberDto>> GetAllAsync(int clanId)
        {
            var members = await _membersRepository.GetAsync(clanId);
            return members.Select(o => _mapper.Map<MemberDto>(o));
        }


        //  /api/members/1/members/2
        [HttpGet("{memberId}")]
        public async Task<ActionResult<MemberDto>> GetAsync(int clanId, int memberId)
        {
            var member = await _membersRepository.GetAsync(clanId, memberId);
            if (member == null) return NotFound($"Member with id '{memberId}' not found.");

            return Ok(_mapper.Map<MemberDto>(member));
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> PostAsync(int clanId, CreateMemberDto memberDto)
        {
            var clan = await _clansRepository.Get(clanId);
            if (clan == null) return NotFound($"Clan with id '{clanId}' not found.");

            var member = _mapper.Map<Member>(memberDto);
            member.ClanId = clanId;

            await _membersRepository.InsertAsync(member);
            return Created($"/api/clans/{clanId}/members/{member.Id}", _mapper.Map<MemberDto>(member));
        }


        [HttpPut("{memberId}")]
        public async Task<ActionResult<MemberDto>> PutAsync(int clanId,int memberId, CreateMemberDto memberDto)
        {
            var clan = await _clansRepository.Get(clanId);
            if (clan == null) return NotFound($"Clan with id '{clanId}' not found.");

            var oldMember = await _membersRepository.GetAsync(clanId, memberId);
            if(oldMember==null) return NotFound();

            //oldMember.Goal = memberDto.Goal;
            _mapper.Map(memberDto, oldMember);

            await _membersRepository.UpdateAsync(oldMember);
            return Ok(_mapper.Map<MemberDto>(oldMember));
        }

        [HttpDelete("{memberId}")]
        public async Task<ActionResult<MemberDto>> Delete(int clanId, int memberId)
        {
            var member = await _membersRepository.GetAsync(clanId, memberId);
            if (member == null) return NotFound($"Member with id '{memberId}' not found.");


            await _membersRepository.DeleteAsync(member);

            //204
            return NoContent();
        }



    }
}
