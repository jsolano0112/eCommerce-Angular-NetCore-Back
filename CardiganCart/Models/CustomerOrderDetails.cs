namespace CardiganCart.Models
{
    public partial class CustomerOrderDetails
    {
        public int Id { get; set; }
        public string OrderId { get; set; } = null!;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
