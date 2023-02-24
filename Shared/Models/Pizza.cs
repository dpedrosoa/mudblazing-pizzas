using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizzas.Shared.Models
{
    /// <summary>
    /// Represents a configured pizza with the default special an its aggregates (toppings)
    /// </summary>
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public int Id { get; set; }
        public int SpecialId { get; set; }
        public PizzaSpecial Special { get; set; }
        public int OrderId { get; set; }
        public int Size { get; set; }
        public List<PizzaTopping> Toppings { get; set; } = new List<PizzaTopping>();

        public decimal GetBasePrice()
        {
            return ((decimal)Size / (decimal)DefaultSize) * Special.BasePrice;
        }

        public decimal GetTotalPrice()
        {
            return GetBasePrice() + Toppings.Sum(x => x.Topping.Price);
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }

    }
}
