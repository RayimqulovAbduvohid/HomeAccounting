namespace HomeAccounting.Api.src.HomeAccounting.Application.DTOs
{
    public class ExpenseReadDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
