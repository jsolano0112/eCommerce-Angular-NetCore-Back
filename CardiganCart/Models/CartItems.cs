namespace CardiganCart.Models
{
    public partial class CartItems
    {
        public int Id { get; set; }
        public string CartId { get; set; } = null!;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
