using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizzas.Shared.Models
{
    public class PizzaTopping
    {
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
