using BlazingPizzas.Server.Data.Repository;
using BlazingPizzas.Shared.Models;


namespace BlazingPizzas.Server.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Order> OrdersRepository { get; }
        public IRepository<PizzaSpecial> SpecialsRepository { get; }
        public IRepository<Topping> ToppingsRepository { get; }

        Task<bool> Save();   
    }
}
