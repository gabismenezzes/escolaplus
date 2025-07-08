using EscolaPlus.Models.ViewModels;

namespace EscolaPlus.Models{
public class ComunicadoViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataPublicacao { get; set; }
    public DateTime? DataExpiracao { get; set; }
    public int TurmaId { get; set; }
    public TurmaViewModel Turma { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioViewModel Usuario { get; set; }
}
}