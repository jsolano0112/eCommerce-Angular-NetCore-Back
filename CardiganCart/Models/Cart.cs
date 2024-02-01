namespace CardiganCart.Models
{
    public partial class Cart
    {
        public string Id { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
