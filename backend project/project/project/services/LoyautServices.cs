using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using project.DAL;
using project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project.services
{
    public class LoyautServices
    {
        private readonly AppDbContext context;

        public LoyautServices(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Setting>> GetData()
        {
            List<Setting> settings = await context.settings.ToListAsync();

            return settings;
        }
    }
}
