using SerieEnum = EscolaPlus.Models.Enums.Serie;
namespace EscolaPlus.Models.ViewModels
{
    public class DisciplinaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int CargaHoraria { get; set; }
        public int SerieId { get; set; }
        public SerieEnum Serie { get; set; }
        public string SerieNome => Serie.ToString();

        public ICollection<TurmaDisciplinaViewModel> TurmasDisciplinas { get; set; } = new List<TurmaDisciplinaViewModel>();
        public ICollection<ProfessorDisciplinaViewModel> ProfessoresDisciplinas { get; set; } = new List<ProfessorDisciplinaViewModel>();
        public ICollection<AlunoDisciplinaViewModel> AlunosDisciplinas { get; set; } = new List<AlunoDisciplinaViewModel>();
    }
}