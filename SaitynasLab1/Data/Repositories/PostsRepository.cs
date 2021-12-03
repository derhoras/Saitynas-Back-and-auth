using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaitynasLab1.Data.Entities;

namespace SaitynasLab1.Data.Repositories
{
    public interface IPostsRepository
    {
        Task<Post> GetAsync(int memberId, int postId); // (int clandId, int memberId, int postId);
        Task<List<Post>> GetAsync(int memberId); //(int clandId, int memberId);
        Task InsertAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
    }
    public class PostsRepository : IPostsRepository
    {
        private readonly DemoRestContext _demoRestContext;

        public PostsRepository(DemoRestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }
        public async Task<Post> GetAsync(int memberId, int postId)
        //public async Task<Post> GetAsync(int clandId, int memberId, int postId)
        {
            return await _demoRestContext.Posts.FirstOrDefaultAsync(o => o.MemberId == memberId && o.Id == postId);
            //return await _demoRestContext.Posts.FirstOrDefaultAsync(o => o.MemberId == memberId && o.Id == postId && o.Memb ClanId);
        }

        public async Task<List<Post>> GetAsync(int memberId)
        //public async Task<List<Post>> GetAsync(int clandId, int memberId)
        {
            return await _demoRestContext.Posts.Where(o => o.MemberId == memberId).ToListAsync();
            //return await _demoRestContext.Posts.Where(o => o.MemberId == memberId).ToListAsync();

        }

        public async Task InsertAsync(Post post)
        {
            _demoRestContext.Posts.Add(post);
            await _demoRestContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(Post post)
        {
            _demoRestContext.Posts.Update(post);
            await _demoRestContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(Post post)
        {
            _demoRestContext.Posts.Remove(post);
            await _demoRestContext.SaveChangesAsync();

        }
    }
}
