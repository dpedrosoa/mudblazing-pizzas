using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizzas.Shared.Models
{
    /// <summary>
    /// Represents a specific type of pizza used as a base for ordering a pizza
    /// </summary>
    public class PizzaSpecial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal BasePrice { get; set; }

        public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
    }
}
