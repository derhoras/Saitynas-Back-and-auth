using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SaitynasLab1.Data.Repositories
{


    public interface IClansRepository
    {
        Task<List<Clan>> GetAll();
        Task<Clan> Get(int id);
        Task Create(Clan clan);
        Task Put(Clan clan);
        Task Delete(Clan clan);

    }
    public class ClansRepository : IClansRepository
    {
        private readonly DemoRestContext _demoRestContext;
        public ClansRepository(DemoRestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }

        //
        public async Task<Clan> Get(int clanId)
        {
            return await _demoRestContext.Clans.FirstOrDefaultAsync(o => o.Id == clanId);
        }

        public async Task<List<Clan>> GetAll()
        {
            return await _demoRestContext.Clans.ToListAsync();
        }

        public async Task Create(Clan clan)
        {
            _demoRestContext.Clans.Add(clan);
            await _demoRestContext.SaveChangesAsync();

        }

        public async Task Put(Clan clan)
        {
            _demoRestContext.Clans.Update(clan);
            await _demoRestContext.SaveChangesAsync();

        }

        public async Task Delete(Clan clan)
        {
            _demoRestContext.Clans.Remove(clan);
            await _demoRestContext.SaveChangesAsync();

        }
        
        //public async Task<IEnumerable<Clan>> GetAll()
        //{
        //    return new List<Clan>
        //    {
        //        new Clan()
        //        {
        //            Name = "Destroyers",
        //            Description = "A clan which is created for players interested in getting Kills",
        //            Type = "PVP",
        //            CreationDate = DateTime.UtcNow
        //        },

        //        new Clan()
        //        {
        //            Name = "Teemos",
        //            Description = "Clan's purpose is to make everyone have a great time",
        //            Type = "Chatting",
        //            CreationDate = DateTime.UtcNow
        //        }
        //    };
        //}


        //public async Task<Clan> Get(int id)
        //{
        //    return new Clan()
        //    {
        //        Name = "Destroyers",
        //        Description = "A clan which is created for players interested in getting Kills",
        //        Type = "PVP",
        //        CreationDate = DateTime.UtcNow
        //    };
        //}


        //public async Task<Clan> Create(Clan clan)
        //{

        //    _demoRestContext.Clans.Add(clan);
        //    await _demoRestContext.SaveChangesAsync();

        //    return clan;
        //    //return new Clan()
        //    //{
        //    //    Name = "Destroyers",
        //    //    Description = "A clan which is created for players interested in getting Kills",
        //    //    Type = "PVP",
        //    //    CreationDate = DateTime.UtcNow
        //    //};
        //}

        //public async Task<Clan> Put(Clan clan)
        //{
        //    return new Clan()
        //    {
        //        Name = "Destroyers",
        //        Description = "A clan which is created for players interested in getting Kills",
        //        Type = "PVP",
        //        CreationDate = DateTime.UtcNow
        //    };
        //}

        //public async Task Delete(Clan clan)
        //{
        //}
    }
}
