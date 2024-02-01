
using Microsoft.EntityFrameworkCore;

namespace CardiganCart.Models
{
    public partial class CardiganDBContext: DbContext
    {
        public CardiganDBContext() { }

        public CardiganDBContext(DbContextOptions<CardiganDBContext> options) : base(options) { }
    
        public virtual DbSet<Cardigan> Cardigan { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }

        public virtual DbSet<Categories> Categories { get; set; }

        public virtual DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }

        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }

        public virtual DbSet<UserMaster> UserMaster { get; set; }

        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }

        protected internal virtual void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cardigan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Price)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id")
                .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                .HasColumnName("UserId");

            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_CartItem");

                entity.Property(e => e.CartId)
                .IsRequired()
                .HasMaxLength(36)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_category");

                entity.Property(e => e.Id)
                .HasColumnName("Id");

                entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrderDetails>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_Customer");

                entity.Property(e => e.OrderId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.Price)
                .HasColumnType("decimal");
            });

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_Customer_C3");

                entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.CartTotal)
                .HasColumnType("decimal(10,2)");

                entity.Property(e => e.DateCreated)
               .HasColumnType("datetime");

                entity.Property(e => e.UserId)
               .HasColumnName("UserID");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_UserMaster");

                entity.Property(e => e.Id)
                 .HasColumnName("UserId");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(6)
                .IsUnicode(false);

                entity.Property(e => e.Lastname)
               .IsRequired()
               .HasMaxLength(20)
               .IsUnicode(false);

                entity.Property(e => e.Password)
               .IsRequired()
               .HasMaxLength(40)
               .IsUnicode(false);

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeId");

                entity.Property(e => e.Username)
               .IsRequired()
               .HasMaxLength(20)
               .IsUnicode(false);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId)
                .HasColumnName("UserTypeId");

                entity.Property(e => e.UserTypeName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
