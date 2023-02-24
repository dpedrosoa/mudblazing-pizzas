using BlazingPizzas.Server.Data.Repository;
using BlazingPizzas.Shared.Models;


namespace BlazingPizzas.Server.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<PizzaSpecial> SpecialsRepository { get; }

        Task<bool> Save();   
    }
}
