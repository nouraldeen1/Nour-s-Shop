using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System;
namespace Nour_Shop.Models;

public partial class NourShopContext : DbContext
{
    public NourShopContext()
    {
    }

    public NourShopContext(DbContextOptions<NourShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-51EDPAQO;Database=Nour Shop;Trusted_Connection=True; Integrated Security = True; Encrypt = False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("date")
                .HasColumnName("delivery date");
            entity.Property(e => e.Number)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("number");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("order date");
            entity.Property(e => e.Payment)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("payment");
            entity.Property(e => e.RemainingTime)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("remaining time");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Times)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("times");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Pid)
                .HasConstraintName("FK_orders_products");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK_orders_Users");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Name");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("brand");
            entity.Property(e => e.Catogary)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("catogary");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("discount");
            entity.Property(e => e.Image)
                .HasColumnType("ntext")
                .HasColumnName("image");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("status");

            entity.HasOne(d => d.OidNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Oid)
                .HasConstraintName("FK_products_orders");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
           // entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("sex");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.OidNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Oid)
                .HasConstraintName("FK_Users_orders");
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
