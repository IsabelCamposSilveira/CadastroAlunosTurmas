namespace CadastroEscola.Models
{
    public class Turma
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public int AnoEscolar { get; set; }
        public Turno Turno { get; set; }

        // Propriedade de navegação para alunos
        public ICollection<Aluno>? Alunos { get; set; }
    }
}
