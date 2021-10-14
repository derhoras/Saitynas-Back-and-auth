using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaitynasLab1.Data.Repositories;
using SaitynasLab1.Data.Entities;
using SaitynasLab1.Data.Dtos.Clans;
using SaitynasLab1.Data.Dtos.Members;
using SaitynasLab1.Data.Dtos.Posts;

namespace SaitynasLab1.Data
{
    public class DemoRestProfile : Profile
    {
        public DemoRestProfile()
        {
            CreateMap<Clan, ClanDto>();
            CreateMap<CreateClanDto, Clan>();
            CreateMap<UpdateClanDto, Clan>();

            CreateMap<Member, MemberDto>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>();

            CreateMap<Post, PostDto>();
            CreateMap<CreatePostDto, Post>();
            CreateMap<UpdatePostDto, Post>();
        }
    }
}
