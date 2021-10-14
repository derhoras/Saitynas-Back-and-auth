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
        Task<IEnumerable<Clan>> GetAll();
        Task<Clan> Get(int id);
        Task<Clan> Create(Clan clan);
        Task<Clan> Put(Clan clan);
        Task Delete(Clan clan);

    }
    public class ClansRepository : IClansRepository
    {
        private readonly DemoRestContext _demoRestContext;
        public ClansRepository(DemoRestContext demoRestContext)
        {
            _demoRestContext = demoRestContext;
        }

        public async Task<IEnumerable<Clan>> GetAll()
        {
            return new List<Clan>
            {
                new Clan()
                {
                    Name = "Destroyers",
                    Description = "A clan which is created for players interested in getting Kills",
                    Type = "PVP",
                    CreationDate = DateTime.UtcNow
                },

                new Clan()
                {
                    Name = "Teemos",
                    Description = "Clan's purpose is to make everyone have a great time",
                    Type = "Chatting",
                    CreationDate = DateTime.UtcNow
                }
            };
        }


        public async Task<Clan> Get(int id)
        {
            return new Clan()
            {
                Name = "Destroyers",
                Description = "A clan which is created for players interested in getting Kills",
                Type = "PVP",
                CreationDate = DateTime.UtcNow
            };
        }


        public async Task<Clan> Create(Clan clan)
        {

            _demoRestContext.Clans.Add(clan);
            await _demoRestContext.SaveChangesAsync();

            return clan;
            //return new Clan()
            //{
            //    Name = "Destroyers",
            //    Description = "A clan which is created for players interested in getting Kills",
            //    Type = "PVP",
            //    CreationDate = DateTime.UtcNow
            //};
        }

        public async Task<Clan> Put(Clan clan)
        {
            return new Clan()
            {
                Name = "Destroyers",
                Description = "A clan which is created for players interested in getting Kills",
                Type = "PVP",
                CreationDate = DateTime.UtcNow
            };
        }

        public async Task Delete(Clan clan)
        {
        }
    }
}
