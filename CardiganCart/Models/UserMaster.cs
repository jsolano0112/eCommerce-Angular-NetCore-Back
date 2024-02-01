namespace CardiganCart.Models
{
    public partial class UserMaster
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int UserTypeId { get; set; }

    }
}
