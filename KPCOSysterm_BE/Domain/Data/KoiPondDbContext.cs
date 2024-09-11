using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Data;

public partial class KoiPondDbContext : DbContext
{
    public KoiPondDbContext()
    {
    }

    public KoiPondDbContext(DbContextOptions<KoiPondDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<ComponentType> ComponentTypes { get; set; }

    public virtual DbSet<Decoration> Decorations { get; set; }

    public virtual DbSet<DecorationType> DecorationTypes { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountPound> DiscountPounds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<PondComponent> PondComponents { get; set; }

    public virtual DbSet<PondDecoration> PondDecorations { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }
    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionStringDB"];
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Accounts_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasIndex(e => e.ComponentTypeId, "IX_Components_ComponentTypeID");

            entity.Property(e => e.ComponentId).HasColumnName("ComponentID");
            entity.Property(e => e.ComponentTypeId).HasColumnName("ComponentTypeID");

            entity.HasOne(d => d.ComponentType).WithMany(p => p.Components).HasForeignKey(d => d.ComponentTypeId);
        });

        modelBuilder.Entity<ComponentType>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Decoration>(entity =>
        {
            entity.ToTable("Decoration");

            entity.HasIndex(e => e.DecorationTypeId, "IX_Decoration_DecorationTypeId");

            entity.HasOne(d => d.DecorationType).WithMany(p => p.Decorations).HasForeignKey(d => d.DecorationTypeId);
        });

        modelBuilder.Entity<DecorationType>(entity =>
        {
            entity.ToTable("DecorationType");
        });

        modelBuilder.Entity<DiscountPound>(entity =>
        {
            entity.HasKey(e => new { e.DiscountId, e.AccountId });

            entity.HasIndex(e => e.AccountId, "IX_DiscountPounds_AccountID");

            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");

            entity.HasOne(d => d.Account).WithMany(p => p.DiscountPounds).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountPounds).HasForeignKey(d => d.DiscountId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Orders_AccountId");

            entity.HasIndex(e => e.DiscountId, "IX_Orders_DiscountID");

            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders).HasForeignKey(d => d.DiscountId);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");

            entity.HasIndex(e => e.PondId, "IX_OrderItems_PondID");

            entity.HasIndex(e => e.ServiceId, "IX_OrderItems_ServiceID");

            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Pond).WithMany(p => p.OrderItems).HasForeignKey(d => d.PondId);

            entity.HasOne(d => d.Service).WithMany(p => p.OrderItems).HasForeignKey(d => d.ServiceId);
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Ponds_AccountID");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.PondDepth).HasColumnName("pondDepth");

            entity.HasOne(d => d.Account).WithMany(p => p.Ponds).HasForeignKey(d => d.AccountId);
        });

        modelBuilder.Entity<PondComponent>(entity =>
        {
            entity.HasKey(e => new { e.PondId, e.ComponentId });

            entity.HasIndex(e => e.ComponentId, "IX_PondComponents_ComponentId");

            entity.Property(e => e.PondId).HasColumnName("PondID");

            entity.HasOne(d => d.Component).WithMany(p => p.PondComponents).HasForeignKey(d => d.ComponentId);

            entity.HasOne(d => d.Pond).WithMany(p => p.PondComponents).HasForeignKey(d => d.PondId);
        });

        modelBuilder.Entity<PondDecoration>(entity =>
        {
            entity.HasKey(e => new { e.PondId, e.DecorationId });

            entity.HasIndex(e => e.DecorationId, "IX_PondDecorations_DecorationId");

            entity.Property(e => e.PondId).HasColumnName("PondID");

            entity.HasOne(d => d.Decoration).WithMany(p => p.PondDecorations).HasForeignKey(d => d.DecorationId);

            entity.HasOne(d => d.Pond).WithMany(p => p.PondDecorations).HasForeignKey(d => d.PondId);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating");

            entity.HasIndex(e => e.AccountId, "IX_Rating_AccountID");

            entity.HasIndex(e => e.OrderItemId, "IX_Rating_OrderItemID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

            entity.HasOne(d => d.Account).WithMany(p => p.Ratings).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.OrderItem).WithMany(p => p.Ratings).HasForeignKey(d => d.OrderItemId);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasIndex(e => e.ServiceTypeId, "IX_Services_ServiceTypeID");

            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Services).HasForeignKey(d => d.ServiceTypeId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Users_AccountID")
                .IsUnique()
                .HasFilter("([AccountID] IS NOT NULL)");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Email).HasDefaultValue("");
            entity.Property(e => e.Gender).HasDefaultValue("");

            entity.HasOne(d => d.Account).WithOne(p => p.User).HasForeignKey<User>(d => d.AccountId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
