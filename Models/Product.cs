namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Supplier { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
