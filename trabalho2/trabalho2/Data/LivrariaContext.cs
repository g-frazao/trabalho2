using Microsoft.EntityFrameworkCore;
using trabalho2.Models;

namespace trabalho2.Data
{
    public class LivrariaContext : DbContext
    {
        internal readonly object Autor;

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasMany(a => a.Livro)
                .WithOne(b => b.AutorId)
                .HasForeignKey(b => b.AutorId);
        }
    }
}