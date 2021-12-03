using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Repositories;
using SaitynasLab1.Data.Entities;
using SaitynasLab1.Data.Dtos.Members;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using SaitynasLab1.Auth.Model;

namespace SaitynasLab1.Controllers
{
    [ApiController]
    [Route("api/clans/{clanId}/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;
        private readonly IClansRepository _clansRepository;
        private readonly IAuthorizationService _authorizationService;

        public MembersController(IMembersRepository membersRepository,IMapper mapper, IClansRepository clansRepository, IAuthorizationService authorizationService)
        {
            _membersRepository = membersRepository;
            _mapper = mapper;
            _clansRepository = clansRepository;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,SimpleUser")]
        public async Task<IEnumerable<MemberDto>> GetAllAsync(int clanId)
        {
            var members = await _membersRepository.GetAsync(clanId);
            return members.Select(o => _mapper.Map<MemberDto>(o));
        }


        //  /api/members/1/members/2
        [HttpGet("{memberId}")]
        [Authorize(Roles = "Admin,SimpleUser")]
        public async Task<ActionResult<MemberDto>> GetAsync(int clanId, int memberId)
        {
            var member = await _membersRepository.GetAsync(clanId, memberId);
            if (member == null) return NotFound($"Member with id '{memberId}' not found.");

            return Ok(_mapper.Map<MemberDto>(member));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SimpleUser")]
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
        [Authorize(Roles = "Admin,SimpleUser")]
        public async Task<ActionResult<MemberDto>> PutAsync(int clanId,int memberId, CreateMemberDto memberDto)
        {
            var clan = await _clansRepository.Get(clanId);
            if (clan == null) return NotFound($"Clan with id '{clanId}' not found.");

            var oldMember = await _membersRepository.GetAsync(clanId, memberId);
            if(oldMember==null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, clan, PolicyNames.SameUser);

            if (!authorizationResult.Succeeded)
            {
                //403
                return Forbid();
            }
            //oldMember.Goal = memberDto.Goal;
            _mapper.Map(memberDto, oldMember);

            await _membersRepository.UpdateAsync(oldMember);
            return Ok(_mapper.Map<MemberDto>(oldMember));
        }

        [HttpDelete("{memberId}")]
        [Authorize(Roles = "Admin,SimpleUser")]
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
