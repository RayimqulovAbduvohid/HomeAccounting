using HomeAccounting.src.HomeAccounting.Application.Services;
using HomeAccounting.src.HomeAccounting.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.src.HomeAccounting.API.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _expenseService.GetAllExpensesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exp = await _expenseService.GetExpenseByIdAsync(id);
            return exp is null ? NotFound() : Ok(exp);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (expense == null)
                return BadRequest("Expense ma'lumotlari yuborilmadi.");

            await _expenseService.AddExpenseAsync(expense);
            return Ok("Xarajat qo‘shildi");
        }
          
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Expense expense)
        {
            expense.Id = id;
            await _expenseService.UpdateExpenseAsync(expense);
            return Ok("Xarajat yangilandi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return Ok("Xarajat o‘chirildi");
        }
    }
}
