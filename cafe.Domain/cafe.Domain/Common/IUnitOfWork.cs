using cafe.Domain.Category.Repository;
using cafe.Domain.Client.Repository;
using cafe.Domain.Employee.Repository;
using cafe.Domain.Event.Repository;
using cafe.Domain.Meal.Repository;
using cafe.Domain.Order.Repository;
using cafe.Domain.Shift;
using cafe.Domain.Table.Repository;
using cafe.Domain.Transaction.Repository;
using cafe.Domain.Users.Repository;

namespace cafe.Domain.Common
{
    public interface IUnitOfWork
    {

        IUserRepository Users { get; }

        ICategoryRepository Categories { get; }

        IClientRepository Clients { get; }

        IEmployeeRepository Employees { get; }

        IEventRepository Events { get; }

        IMealRepository Meals { get; }

        IOrderRepository Orders { get; }

        IShiftRepository Shifts { get; }

        ITableRepository Tables { get; }

        ITransactionRepository Transactions { get; }

        Task CompleteAsync();
    }
}

