using Microsoft.EntityFrameworkCore;

namespace OrderApi.Models
{
    [Index(nameof(Number))]
    public class PostTerminal
    {
        public string Number { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
