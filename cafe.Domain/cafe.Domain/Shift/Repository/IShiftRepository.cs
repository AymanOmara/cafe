using cafe.Domain.Common;
using cafe.Domain.Order.Entity;
using cafe.Domain.Shift.Entity;

namespace cafe.Domain.Shift
{
	public interface IShiftRepository
	{
		Task<Result<ShiftEntity,Exception>> StartNewShift();

		Task<Result<bool,Exception>> CloseCurrentShift();

		Task<ShiftEntity?> GetCurrentActiveShift();

		Task<ICollection<OrderEntity>> GetOrdersOnShift(int shiftId);
	}
}

