using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RezerwacjaSamochodow.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet for Cars
    public DbSet<Car> Cars { get; set; }

    // DbSet for Reservations
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed data for Cars
        builder.Entity<Car>().HasData(
            new Car { Id = 1, Brand = "Peugeot", Model = "308", Year = 2019, PricePerDay = 45.00m },
            new Car { Id = 2, Brand = "Honda", Model = "Civic", Year = 2021, PricePerDay = 55.00m },
            new Car { Id = 3, Brand = "Ford", Model = "Focus", Year = 2019, PricePerDay = 45.00m },
            new Car { Id = 4, Brand = "BMW", Model = "3 Series", Year = 2022, PricePerDay = 80.00m },
            new Car { Id = 5, Brand = "Mercedes", Model = "C-Class", Year = 2021, PricePerDay = 90.00m },
            new Car { Id = 6, Brand = "Audi", Model = "A4", Year = 2020, PricePerDay = 85.00m },
            new Car { Id = 7, Brand = "Volkswagen", Model = "Golf", Year = 2018, PricePerDay = 40.00m },
            new Car { Id = 8, Brand = "Hyundai", Model = "Elantra", Year = 2019, PricePerDay = 42.00m },
            new Car { Id = 9, Brand = "Kia", Model = "Optima", Year = 2020, PricePerDay = 48.00m },
            new Car { Id = 10, Brand = "Mazda", Model = "Mazda3", Year = 2021, PricePerDay = 50.00m },
            new Car { Id = 11, Brand = "Subaru", Model = "Impreza", Year = 2022, PricePerDay = 52.00m },
            new Car { Id = 12, Brand = "Nissan", Model = "Altima", Year = 2021, PricePerDay = 55.00m },
            new Car { Id = 13, Brand = "Chevrolet", Model = "Malibu", Year = 2020, PricePerDay = 53.00m },
            new Car { Id = 14, Brand = "Tesla", Model = "Model 3", Year = 2023, PricePerDay = 100.00m }
        );
        builder.Entity<Reservation>()
            .Property(r => r.StartDate)
            .HasConversion(
                v => v.ToUniversalTime(),  
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));  
        builder.Entity<Reservation>()
            .Property(r => r.EndDate)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }

}