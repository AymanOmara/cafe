using cafe.Domain.Transaction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    [Authorize(Roles = "Admin,Acountent")]
    [Route("api/[controller]")]
	public class TransactionController:ControllerBase
	{
		private readonly ITransactionService _service;

		public TransactionController(ITransactionService service)
		{
			_service = service;
		}
		[HttpGet("AllTransactions")]
		public async Task<ActionResult> GetAllTransactions() {
			return Ok(await _service.GetAllTransactions());
		}
	}
}

