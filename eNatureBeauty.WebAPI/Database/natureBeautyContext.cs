using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class natureBeautyContext : DbContext
    {
        public natureBeautyContext()
        {
        }

        public natureBeautyContext(DbContextOptions<natureBeautyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IngredientTypes> IngredientTypes { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<IngredientsIngredientTypes> IngredientsIngredientTypes { get; set; }
        public virtual DbSet<InputProducts> InputProducts { get; set; }
        public virtual DbSet<Inputs> Inputs { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OutputProducts> OutputProducts { get; set; }
        public virtual DbSet<Outputs> Outputs { get; set; }
        public virtual DbSet<ProductIngredients> ProductIngredients { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Storages> Storages { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<UserAddresses> UserAddresses { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersUserTypes> UsersUserTypes { get; set; }
        public virtual DbSet<Wishlists> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=natureBeauty;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientTypes>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasIndex(e => e.UnitId);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredients_Units");
            });

            modelBuilder.Entity<IngredientsIngredientTypes>(entity =>
            {
                entity.HasIndex(e => e.IngredientId);

                entity.HasIndex(e => e.IngredientTypeId);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.IngredientTypeId).HasColumnName("IngredientTypeID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientsIngredientTypes)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientsIngredientTypes_Ingredients");

                entity.HasOne(d => d.IngredientType)
                    .WithMany(p => p.IngredientsIngredientTypes)
                    .HasForeignKey(d => d.IngredientTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientsIngredientTypes_IngredientTypes");
            });

            modelBuilder.Entity<InputProducts>(entity =>
            {
                entity.HasIndex(e => e.InputId);

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.InputId).HasColumnName("InputID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Input)
                    .WithMany(p => p.InputProducts)
                    .HasForeignKey(d => d.InputId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputProducts_Inputs");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InputProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputProducts_Products");
            });

            modelBuilder.Entity<Inputs>(entity =>
            {
                entity.HasIndex(e => e.StorageId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceAmountWithPdv)
                    .HasColumnName("InvoiceAmountWithPDV")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.Pdv)
                    .HasColumnName("PDV")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.StorageId).HasColumnName("StorageID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Inputs)
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inputs_Storages");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Inputs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inputs_Users");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OutputProducts>(entity =>
            {
                entity.HasIndex(e => e.OutputId);

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.OutputId).HasColumnName("OutputID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Output)
                    .WithMany(p => p.OutputProducts)
                    .HasForeignKey(d => d.OutputId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputProducts_Outputs");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OutputProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputProducts_Products");
            });

            modelBuilder.Entity<Outputs>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ReceiveNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ValueWithPdv)
                    .HasColumnName("ValueWithPDV")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValueWithoutPdv)
                    .HasColumnName("ValueWithoutPDV")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Outputs_Orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Outputs_Users");
            });

            modelBuilder.Entity<ProductIngredients>(entity =>
            {
                entity.HasIndex(e => e.IngredientId);

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.ProductIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductIngredients_Ingredients");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductIngredients)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductIngredients_Products");
            });

            modelBuilder.Entity<ProductTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.ProductTypeId);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductTypes");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Users");
            });

            modelBuilder.Entity<Storages>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserAddresses>(entity =>
            {
                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("CS_Email")
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.HasIndex(e => e.UserName)
                    .HasName("CS_UserName")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PasswordSalt).HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Telephone).HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.UserAddress)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserAddressId)
                    .HasConstraintName("FK__Users__UserAddre__0E391C95");
            });

            modelBuilder.Entity<UsersUserTypes>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.UserTypeId);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersUserTypes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersUserTypes_Users");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UsersUserTypes)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersUserTypes_UserTypes");
            });

            modelBuilder.Entity<Wishlists>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wishlists_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wishlists_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
