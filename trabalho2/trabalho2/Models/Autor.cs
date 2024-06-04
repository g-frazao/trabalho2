namespace trabalho2.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public List<Livro> Livro { get; set; } = new List<Livro>();
    }
}