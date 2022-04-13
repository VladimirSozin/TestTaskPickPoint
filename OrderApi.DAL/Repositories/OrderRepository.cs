using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApi.DAL.Abstractions;
using OrderApi.DAL.Interfaces;
using OrderApi.Models;

namespace OrderApi.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderApiContext context) : base(context) { }
        
        public IQueryable<Order> GetOrders()
        {
            return Context.Orders
                .AsQueryable();
        }

        public async Task CancelAsync(int orderNumber)
        {
            var order = await Context.Orders
                .FirstOrDefaultAsync(o => o.Number == orderNumber);

            if (order != null)
            {
                order.Status = OrderStatuses.Canceled;
                await UpdateAsync(order);
            }
        }
    }
}
