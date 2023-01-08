using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class DataDbcontext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DataDbcontext(DbContextOptions<DataDbcontext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerBill> CustomerBill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(entity => entity.ProductId);
            modelBuilder.Entity<Product>().Property(e => e.ProductId);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("HTC_PRODUCT");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Desc)
                    .HasColumnName("DECRIPSTION")
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.Property(e => e.Name)
                .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(150)
                    .IsUnicode(true);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("PRICE")
                    .IsUnicode(false);

                entity.Property(e => e.imageUrl)
                    .HasColumnName("IMAGE_URL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                .IsRequired()
                    .HasColumnName("CATEGORY_ID")
                    .IsUnicode(false);                
            });

            modelBuilder.Entity<Category>().HasKey(entity => entity.CategoryId);
            modelBuilder.Entity<Category>().Property(e => e.CategoryId);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("HTC_CATEGORY");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                .IsRequired()
                    .HasColumnName("TITLE")
                    .HasMaxLength(150)
                    .IsUnicode(true);
            });
            modelBuilder.Entity<Customer>().HasKey(entity => entity.CustomerId);
            modelBuilder.Entity<Customer>().Property(e => e.CustomerId);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("HTC_CUSTOMER");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.birthay)
                    .HasColumnName("BIRTHDAY")
                    .HasColumnType("DATE");

                entity.Property(e => e.email)
                .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.number)
                .IsRequired()
                    .HasColumnName("NUMBER")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });
            modelBuilder.Entity<CustomerBill>().HasKey(entity => entity.Id);
            modelBuilder.Entity<CustomerBill>().Property(e => e.Id);
            modelBuilder.Entity<CustomerBill>(entity =>
            {
                entity.ToTable("HTC_CUSTOMER_BILL");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.sumPrice)
                    .HasColumnName("SUM_PRICE")
                                    .IsRequired();

                entity.Property(e => e.billDate)
                .IsRequired()
                    .HasColumnName("BILL_DATE")
                    .HasColumnType("DATE");
      

                entity.Property(e => e.nameCustomer)
                .IsRequired()
                    .HasColumnName("NAME_CUSTOMER")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.numberCustomer)
                    .HasColumnName("NUMBER_CUSTOMER")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.lstProductId)
                .IsRequired()
                    .HasColumnName("LIST_PRODUCT_ID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

        }
    }
}
