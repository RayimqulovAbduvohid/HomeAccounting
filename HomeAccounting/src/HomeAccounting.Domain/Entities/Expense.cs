namespace HomeAccounting.src.HomeAccounting.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }                  
        public int CategoryId { get; set; }          
        public decimal Price { get; set; }           
        public string? Description { get; set; }     
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 

        
        public Category? Category { get; set; } = null!;
    }
}
