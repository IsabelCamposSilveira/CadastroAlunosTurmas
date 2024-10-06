using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using CadastroEscola.Models; // Certifique-se de incluir este namespace

namespace CadastroEscola.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; } // Adiciona o DbSet para Turmas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para a entidade Aluno
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.Property(e => e.Genero)
                      .HasConversion(
                          v => v.ToString(),
                          v => (Genero)Enum.Parse(typeof(Genero), v));
            });

            // Configuração para a entidade Turma (se necessário)
            modelBuilder.Entity<Turma>(entity =>
            {
                entity.Property(t => t.Nome)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(t => t.Turno)
                      .HasConversion<string>() // Armazena o enum como string no banco de dados
                      .IsRequired();

                entity.Property(t => t.AnoEscolar)
                      .IsRequired();
            });
        }
    }
}
