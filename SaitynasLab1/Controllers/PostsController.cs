﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Repositories;
using SaitynasLab1.Data.Entities;
using SaitynasLab1.Data.Dtos.Posts;
using AutoMapper;

namespace SaitynasLab1.Controllers
{
    [ApiController]
    [Route("api/clans/{clanId}/members/{memberId}/posts")]
    public class PostsController : ControllerBase
    {

        private readonly IPostsRepository _postsRepository;
        private readonly IMembersRepository _membersRepository;
        private readonly IClansRepository _clansRepository;
        private readonly IMapper _mapper;


        public PostsController(IPostsRepository postsRepository, IMembersRepository membersRepository, IMapper mapper, IClansRepository clansRepository)
        {
            _postsRepository = postsRepository;
            _membersRepository = membersRepository;
            _mapper = mapper;
            _clansRepository = clansRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> GetAllAsync(int memberId)
        {
            var posts = await _postsRepository.GetAsync(memberId);
            return posts.Select(o => _mapper.Map<PostDto>(o));
        }


        //  /api/members/1/members/2/posts/3
        [HttpGet("{postId}")]
        public async Task<ActionResult<PostDto>> GetAsync(int memberId, int postId)
        {
            var post = await _postsRepository.GetAsync(memberId, postId);
            if (post == null) return NotFound($"Post with id '{postId}' not found.");

            return Ok(_mapper.Map<PostDto>(post));
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> PostAsync(int memberId, CreatePostDto postDto)
        {
            var member = await _membersRepository.GetAsync(memberId);
            if (member == null) return NotFound($"Member with id '{memberId}' not found.");

            var post = _mapper.Map<Post>(postDto);
            post.MemberId = memberId;

            await _postsRepository.InsertAsync(post);
            //return Created($"/api/clans/{clanId}/members/{memberId}/posts/{post.Id}", _mapper.Map<PostDto>(post));
            return Created($"/api/clans/2/members/{memberId}/posts/{post.Id}", _mapper.Map<PostDto>(post));
        }


        [HttpPut("{postId}")]
        public async Task<ActionResult<PostDto>> PutAsync(int memberId, int postId, CreatePostDto postDto)
        {
            var member = await _membersRepository.GetAsync(memberId);
            if (member == null) return NotFound($"Member with id '{memberId}' not found.");

            var oldPost = await _postsRepository.GetAsync(memberId, postId);
            if (oldPost == null) return NotFound();

            //
            _mapper.Map(postDto, oldPost);

            await _postsRepository.UpdateAsync(oldPost);
            return Ok(_mapper.Map<PostDto>(oldPost));
        }

        [HttpDelete("{postId}")]
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
