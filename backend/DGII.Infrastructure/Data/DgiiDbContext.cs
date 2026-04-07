using DGII.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DGII.Infrastructure.Data;

public class DgiiDbContext(DbContextOptions<DgiiDbContext> options) : DbContext(options)
{
    public DbSet<Contribuyente> Contribuyentes => Set<Contribuyente>();
    public DbSet<ComprobanteFiscal> ComprobantesFiscales => Set<ComprobanteFiscal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contribuyente>().HasKey(c => c.RncCedula);

        modelBuilder.Entity<Contribuyente>().HasData(
            new Contribuyente { RncCedula = "98754321012", Nombre = "JUAN PEREZ", Tipo = "PERSONA FISICA", Estatus = "activo" },
            new Contribuyente { RncCedula = "123456789", Nombre = "FARMACIA TU SALUD", Tipo = "PERSONA JURIDICA", Estatus = "inactivo" }
        );

        modelBuilder.Entity<ComprobanteFiscal>().HasData(
            new ComprobanteFiscal { Id = 1, RncCedula = "98754321012", NCF = "E310000000001", Monto = 200.00m, Itbis18 = 36.00m },
            new ComprobanteFiscal { Id = 2, RncCedula = "98754321012", NCF = "E310000000002", Monto = 1000.00m, Itbis18 = 180.00m },
            new ComprobanteFiscal { Id = 3, RncCedula = "123456789", NCF = "E310000000003", Monto = 500.00m, Itbis18 = 90.00m }
        );
    }
}