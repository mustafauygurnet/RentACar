using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Domain.Entities;

namespace RentACar.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    private IConfiguration Configuration { get; set; }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
       


    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //    base.OnConfiguring(
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(a =>
        {
            a.ToTable("Brands").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Name).HasColumnName("Name");
            a.HasMany(b=>b.Models);
        });
        
        modelBuilder.Entity<Model>(a =>
        {
            a.ToTable("Models").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.BrandId).HasColumnName("BrandId");
            a.Property(p => p.Name).HasColumnName("Name");
            a.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
            a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
            a.HasOne(m=>m.Brand);
        });



        Brand[] brandEntitySeeds = { new(1, "Audi"), new(2, "Mercedes") };
        modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);
        
        Model[] modelEntitySeeds =
        {
            new(1, 1,"A3",1500,""), 
            new(2, 1,"A4",1600,""),
            new(3, 2,"Mercedes Benz CLA Coupe",1900,""),
        };
        modelBuilder.Entity<Model>().HasData(modelEntitySeeds);

           
    }
}