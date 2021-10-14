using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SaitynasLab1.Data.Repositories
{

    public interface IMembersRepository
    {
        Task<Member> GetAsync(int clanId, int memberId);
        Task<List<Member>> GetAsync(int clanId);
        Task InsertAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(Member member);
    }
    public class MembersRepository : IMembersRepository
    {
        private readonly DemoRestContext _demoRestContext;

        public MembersRepository(DemoRestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }
        public async Task<Member> GetAsync(int clanId, int memberId)
        {
            return await _demoRestContext.Members.FirstOrDefaultAsync(o => o.ClanId == clanId && o.Id == memberId);
        }

        public async Task<List<Member>> GetAsync(int clanId)
        {
            return await _demoRestContext.Members.Where(o => o.ClanId == clanId).ToListAsync();
        }

        public async Task InsertAsync(Member member)
        {
            _demoRestContext.Members.Add(member);
            await _demoRestContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(Member member)
        {
            _demoRestContext.Members.Update(member);
            await _demoRestContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(Member member)
        {
            _demoRestContext.Members.Remove(member);
            await _demoRestContext.SaveChangesAsync();

        }
    }
}
