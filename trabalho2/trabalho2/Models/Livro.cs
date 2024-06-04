using Microsoft.EntityFrameworkCore;

namespace trabalho2.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Título { get; set; }
        public int AutorId { get; set; }
        public EntityState State { get; internal set; }
    }
}
