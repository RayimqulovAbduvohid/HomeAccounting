using HomeAccounting.src.HomeAccounting.Application.Services;
using HomeAccounting.src.HomeAccounting.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HomeAccounting.src.HomeAccounting.API.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpensesController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _expenseService.GetAllExpensesAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Expense exp = await _expenseService.GetExpenseByIdAsync(id);
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
          
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Expense expense)
        {
            expense.Id = id;
            await _expenseService.UpdateExpenseAsync(expense);
            return Ok("Xarajat yangilandi");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseService.DeleteExpenseAsync(id);
            return Ok("Xarajat o‘chirildi");
        }
    }
}
