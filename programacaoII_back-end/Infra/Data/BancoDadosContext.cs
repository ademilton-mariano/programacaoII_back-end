using Microsoft.EntityFrameworkCore;
using programacaoII_back_end.Domain.Entities;

namespace programacaoII_back_end.Infra.Data;

public class BancoDadosContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public BancoDadosContext(DbContextOptions<BancoDadosContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
        modelBuilder.Entity<Tarefa>().HasKey(t => t.Id);
        modelBuilder.Entity<Tarefa>().HasOne<Usuario>(t => t.Usuario)
            .WithMany(u => u.Tarefas);
        
    }
}