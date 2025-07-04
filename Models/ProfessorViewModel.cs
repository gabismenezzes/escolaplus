public class Professor {
    public int Id { get; set; }
    public string Matricula { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario TipoUsuario { get; set; } 
    public DateTime DataNascimento { get; set; }
    public string FormacaoAcademica { get; set; }
    public string Observacoes { get; set; }
    
    // Relacionamentos
    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
    public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    public ICollection<Falta> Faltas { get; set; }
    public ICollection<Atividade> Atividades { get; set; } = new List<
}