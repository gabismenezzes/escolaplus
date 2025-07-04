public class Responsavel {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Celular { get; set; }
    public string Endereco { get; set; }
    public string Profissao { get; set; }
    public string Empresa { get; set; }
    public string Cargo { get; set; }
    public DateTime DataNascimento { get; set; }
    
    // Relacionamento com Aluno
    public ICollection<ResponsavelAluno> Alunos { get; set; } = new List<Aluno>();
}