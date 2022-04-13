using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models.Extensions;

namespace OrderApi.Models
{
    [Index(nameof(Number))]
    public class Order
    {
        public int Number { get; set; }
        public OrderStatuses Status { get; set; }
        [ProductsAttribute]
        public List<string> Products { get; set; }
        public decimal Price { get; set; }
        [PostTerminalNumberAttribute]
        public string PostTerminalNumber { get; set; }
        [PhoneNumberAttribute]
        public string PhoneNumber { get; set; }
        public string RecipientFullName { get; set; }

        public virtual PostTerminal PostTerminal { get; set; }
    }
}