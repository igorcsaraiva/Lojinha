using Loja.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Context
{
    public class LojaContexto : DbContext
    {
        public LojaContexto(DbContextOptions<LojaContexto> options) : base(options)
        {
        }

        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>().HasIndex(p => p.Codigo).IsUnique();
            modelBuilder.Entity<Produto>().HasIndex(p => p.Codigo).IsUnique();

            modelBuilder.Entity<Produto>().OwnsOne(p => p.CodigoBarras, codigoBarras =>
            {
                codigoBarras.HasIndex(c => c.Codigo).IsUnique();
                codigoBarras.Property(c => c.Codigo)
               .IsRequired()
               .HasColumnName("CodigoBarras")
               .HasColumnType("varchar(49)");
            });

            modelBuilder.Entity<Produto>().OwnsOne(p => p.ValorDeVenda, dinheiro =>
            {
                dinheiro.Property(d => d.Valor)
               .IsRequired()
               .HasColumnName("ValorDeVenda")
               .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.HasIndex(c => c.Cpf).IsUnique();
                cpf.Property(c => c.Cpf)
               .IsRequired()
               .HasColumnName("CPF")
               .HasColumnType("varchar(11)");
            });
        }
    }
}
