using EscolaPlus.Models.ViewModels;

namespace EscolaPlus.Models.ViewModels{
public class ProfessorViewModel {
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
    public UsuarioViewModel Usuario { get; set; }
    public int UsuarioId { get; set; }
    public ICollection<TurmaViewModel> Turmas { get; set; } = new List<TurmaViewModel>();
    public ICollection<DisciplinaViewModel> Disciplinas { get; set; } = new List<DisciplinaViewModel>();
    public ICollection<NotaViewModel> Notas { get; set; } = new List<NotaViewModel>();
    public ICollection<AtividadeViewModel> Atividades { get; set; } = new List<AtividadeViewModel>();
}
}