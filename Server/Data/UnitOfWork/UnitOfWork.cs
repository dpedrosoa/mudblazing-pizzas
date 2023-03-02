using BlazingPizzas.Server.Data;
using BlazingPizzas.Server.Data.Repository;
using BlazingPizzas.Shared.Models;

namespace BlazingPizzas.Server.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        #region Repositories
        private IRepository<Order> _OrdersRepository;
        public IRepository<Order> OrdersRepository => _OrdersRepository ?? new Repository<Order>(_context);

        private IRepository<PizzaSpecial> _SpecialsRepository;
        public IRepository<PizzaSpecial> SpecialsRepository => _SpecialsRepository ?? new Repository<PizzaSpecial>(_context);

        private IRepository<Topping> _ToppingsRepository;
        public IRepository<Topping> ToppingsRepository => _ToppingsRepository ?? new Repository<Topping>(_context);

        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> Save()
        {
            int saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
