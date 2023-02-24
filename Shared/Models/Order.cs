using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizzas.Shared.Models
{
    /// <summary>
    /// Represents an order with the configured pizzas included
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public decimal GetTotalPrice()
        {
            return Pizzas.Sum(x=>x.GetTotalPrice());
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}
