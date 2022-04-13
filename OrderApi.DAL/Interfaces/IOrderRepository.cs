using System.Linq;
using System.Threading.Tasks;
using OrderApi.Models;

namespace OrderApi.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task InsertAsync(Order order);
        Task UpdateAsync(Order entity);
        IQueryable<Order> GetOrders();
        Task CancelAsync(int orderNumber);
    }
}
