using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Repositories;
using SaitynasLab1.Data.Entities;
using SaitynasLab1.Data.Dtos.Posts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace SaitynasLab1.Controllers
{
    [ApiController]
    [Route("api/clans/{clanId}/members/{memberId}/posts")]
    public class PostsController : ControllerBase
    {

        private readonly IPostsRepository _postsRepository;
        private readonly IMembersRepository _membersRepository;
        private readonly IClansRepository _clansRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;


        public PostsController(IPostsRepository postsRepository, IMembersRepository membersRepository, IMapper mapper, IClansRepository clansRepository, IAuthorizationService authorizationService)
        {
            _postsRepository = postsRepository;
            _membersRepository = membersRepository;
            _mapper = mapper;
            _clansRepository = clansRepository;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,SimpleUser")]
        public async Task<IEnumerable<PostDto>> GetAllAsync(int memberId)//(int clanId, int memberId)
        {
            var posts = await _postsRepository.GetAsync(memberId);
            return posts.Select(o => _mapper.Map<PostDto>(o));
        }


        //  /api/members/1/members/2/posts/3
        [HttpGet("{postId}")]
        [Authorize(Roles = "Admin,SimpleUser")]
        public async Task<ActionResult<PostDto>> GetAsync(int memberId, int postId)//(int clanId, int memberId, int postId)
        {
            var post = await _postsRepository.GetAsync(memberId, postId);
            if (post == null) return NotFound($"Post with id '{postId}' not found.");

            return Ok(_mapper.Map<PostDto>(post));
        }

        [HttpPost]
        [Authorize(Roles = "SimpleUser")]
        public async Task<ActionResult<PostDto>> PostAsync(int memberId, CreatePostDto postDto)//(int clanId, int memberId, CreatePostDto postDto)
        {
            //var clan = await _clansRepository.Get(clanId);
            //if (clan == null) return NotFound($"Clan with id '{clanId}' not found.");

            var member = await _membersRepository.GetAsync(memberId);
            if (member == null) return NotFound($"Member with id '{memberId}' not found.");
            //var member = await _membersRepository.GetAsync(clanId, memberId);
            //if (member == null) return NotFound($"Member with id '{memberId}' not found.");

            var post = _mapper.Map<Post>(postDto);
            post.MemberId = memberId;

            await _postsRepository.InsertAsync(post);
            //return Created($"/api/clans/{clanId}/members/{memberId}/posts/{post.Id}", _mapper.Map<PostDto>(post));
            return Created($"/api/clans/2/members/{memberId}/posts/{post.Id}", _mapper.Map<PostDto>(post));
        }


        [HttpPut("{postId}")]
        [Authorize(Roles = "SimpleUser")]
        public async Task<ActionResult<PostDto>> PutAsync(int memberId, int postId, CreatePostDto postDto)//((int clanId, int memberId, int postId, CreatePostDto postDto))
        {

            //var clan = await _clansRepository.Get(clanId);
            //if (clan == null) return NotFound($"Clan with id '{clanId}' not found.");

            var member = await _membersRepository.GetAsync(memberId);
            if (member == null) return NotFound($"Member with id '{memberId}' not found.");

            // var member = await _membersRepository.GetAsync(clanId, memberId);
            //if (member == null) return NotFound($"Member with id '{memberId}' not found.");

            var oldPost = await _postsRepository.GetAsync(memberId, postId);
            if (oldPost == null) return NotFound();

            // var oldPost = await _postsRepository.GetAsync(clanId, memberId, postId);
            //if (oldPost == null) return NotFound();

            _mapper.Map(postDto, oldPost);

            await _postsRepository.UpdateAsync(oldPost);
            return Ok(_mapper.Map<PostDto>(oldPost));
        }

        [HttpDelete("{postId}")]
        [Authorize(Roles = "Admin,SimpleUser")]
        public async Task<ActionResult<PostDto>> Delete(int memberId, int postId)
        {
            var post = await _postsRepository.GetAsync(memberId, postId);
            if (post == null) return NotFound($"Post with id '{postId}' not found.");


            await _postsRepository.DeleteAsync(post);

            //204
            return NoContent();
        }
    }
}
