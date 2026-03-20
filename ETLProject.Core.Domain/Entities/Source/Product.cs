
namespace ETLProjectDW.Core.Domain.Entities
{
    public class Product : CommonEntity<int>
    {
        public required string ProductName { get; set; } 

        public required int CategoryID { get; set; }
        public Category? Category { get; set; } 

        public required decimal Price { get; set; }
        public required int Stock { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
