namespace HomeAccounting.Api.src.HomeAccounting.Application.DTOs
{
    public class ExpenseDto
    {
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
