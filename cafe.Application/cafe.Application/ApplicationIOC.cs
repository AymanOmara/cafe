using cafe.Application.Features.Category.Service;
using cafe.Application.Features.Client.Service;
using cafe.Application.Features.Employee.Service;
using cafe.Application.Features.Event;
using cafe.Application.Features.Meal;
using cafe.Application.Features.Order.Service;
using cafe.Application.Features.Shift;
using cafe.Application.Features.Table.Service;
using cafe.Application.Features.Transaction.Service;
using cafe.Application.Features.User.Service;
using cafe.Domain.Category.Service;
using cafe.Domain.Client.Service;
using cafe.Domain.Employee.Service;
using cafe.Domain.Event.Service;
using cafe.Domain.Features.Meal.Service;
using cafe.Domain.Order.Service;
using cafe.Domain.Shift.Service;
using cafe.Domain.Table.Service;
using cafe.Domain.Transaction.Service;
using cafe.Domain.Users.Service;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Application
{
	public static class ApplicationIOC
	{
		public static void RegisterApplicationIOC(this IServiceCollection services)
		{
            /// ********* Category **********
            services.AddScoped<ICategoryService, CategoryService>();

            /// ********* Meal **********
            services.AddScoped<IMealService, MealService>();

            /// ********* Employee **********
            services.AddScoped<IEmployeeService, EmployeeService>();

            /// ********* Table **********
            services.AddScoped<ITableService, TableService>();

            /// ********* Client **********
            services.AddScoped<IClientService, ClientService>();

            /// ********* Event **********
            services.AddScoped<IEventService, EventService>();

            /// ********* Transaction **********
            services.AddScoped<ITransactionService, TransactionService>();

            /// ********* User **********
            services.AddScoped<IUserService, UserService>();

            /// ********* Shift **********
            services.AddScoped<IShiftService, ShiftService>();

            /// ********* Order **********
            services.AddScoped<IOrderService, OrderService>();

            /// ********* AutoMapper **********
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
	}
}

