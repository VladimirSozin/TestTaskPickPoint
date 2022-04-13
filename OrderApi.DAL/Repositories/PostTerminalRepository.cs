using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApi.DAL.Abstractions;
using OrderApi.DAL.Interfaces;
using OrderApi.Models;

namespace OrderApi.DAL.Repositories
{
    public class PostTerminalRepository : BaseRepository<PostTerminal>, IPostTerminalRepository
    {
        public PostTerminalRepository(OrderApiContext context) : base(context) { }

        public async Task<PostTerminal> GetPostTerminalAsync(string postTerminalNumber)
        {
            return await Context.Terminals
                .FirstOrDefaultAsync(m => m.Number == postTerminalNumber);
        }

        public IQueryable<PostTerminal> GetPostTerminals()
        {
            return Context.Terminals
                .AsQueryable();
        }
    }
}
