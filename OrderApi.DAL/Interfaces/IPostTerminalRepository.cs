using System.Linq;
using System.Threading.Tasks;
using OrderApi.Models;

namespace OrderApi.DAL.Interfaces
{
    public interface IPostTerminalRepository
    {
        Task<PostTerminal> GetPostTerminalAsync(string postTerminalNumber);
        IQueryable<PostTerminal> GetPostTerminals();
    }
}
