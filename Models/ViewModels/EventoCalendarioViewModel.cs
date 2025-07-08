using EscolaPlus.Models.ViewModels;

namespace EscolaPlus.Models.ViewModels{
public class EventoCalendarioViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int TurmaId { get; set; }
    public TurmaViewModel Turma { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioViewModel Usuario { get; set; }
}
}