using cafe.Domain.Category.Repository;
using cafe.Domain.Client.Repository;
using cafe.Domain.Common;
using cafe.Domain.Employee.Repository;
using cafe.Domain.Event.Repository;
using cafe.Domain.Meal.Repository;
using cafe.Domain.Order.Repository;
using cafe.Domain.Shift;
using cafe.Domain.Table.Repository;
using cafe.Domain.Transaction.Repository;
using cafe.Domain.Users.entity;
using cafe.Domain.Users.Repository;
using cafe.infrastructure.Features.Category.Repository;
using cafe.infrastructure.Features.Client.Repository;
using cafe.infrastructure.Features.Employee.Repository;
using cafe.infrastructure.Features.Event;
using cafe.infrastructure.Features.Meal.Repository;
using cafe.infrastructure.Features.Order.Repository;
using cafe.infrastructure.Features.Shift;
using cafe.infrastructure.Features.Table.Repository;
using cafe.infrastructure.Features.Transaction.Repository;
using cafe.infrastructure.Features.User.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using cafe.Common;

namespace cafe.infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CafeDbContext _context;
        public readonly UserManager<CafeUser> _userManager;
        public readonly SignInManager<CafeUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly LanguageService _localization;

        /// ********* Repositories **********
        public IUserRepository Users { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IClientRepository Clients { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public IEventRepository Events { get; private set; }

        public IMealRepository Meals { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IShiftRepository Shifts { get; private set; }

        public ITableRepository Tables { get; private set; }

        public ITransactionRepository Transactions { get; private set; }


        public UnitOfWork(CafeDbContext context,
            UserManager<CafeUser> userManager,
            SignInManager<CafeUser> signInManager,
            IConfiguration configuration,
            LanguageService localization
            )
        {
            _context = context;
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _localization = localization;

            InitializeRepositories();
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        private void InitializeRepositories()
        {
            Users = new UserRepository(
                _userManager,
                _signInManager,
                _configuration,
                _context,_localization);
            Categories = new CategoryRepository(_context, _localization);

            Clients = new ClientRepository(_context, _localization);

            Employees = new EmployeeRepository(_context, _localization);

            Events = new EventRepository(_context, _localization);

            Meals = new MealRepository(_context, _localization);

            Orders = new OrderRepository(_context, _localization);

            Shifts = new ShiftRepository(_context, _localization);

            Tables = new TableRepository(_context, _localization);

            Transactions = new TransactionRepository(_context, _localization);
        }
    }
}