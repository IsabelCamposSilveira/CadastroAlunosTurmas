namespace CadastroEscola.Models
{
    public class Aluno
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public string? Telefone { get; set; }
        public string? Bairro { get; set; }
        public string? RuaNumero { get; set; }
        public Genero Genero { get; set; }

                // Nova coluna TurmaID e propriedade de navegação
        public int? TurmaID { get; set; }
        public Turma? Turma { get; set; } // Propriedade de navegação
    }
}
