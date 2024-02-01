namespace CardiganCart.Models
{
    public partial class CustomerOrders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal CartTotal { get; set; }
    }
}
