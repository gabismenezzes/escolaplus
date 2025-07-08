namespace EscolaPlus.Models.ViewModels
{
    public class TurmaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnoLetivo { get; set; }

        public ICollection<AlunoViewModel> Alunos { get; set; } = new List<AlunoViewModel>();
        public ICollection<TurmaDisciplinaViewModel> Disciplinas { get; set; } = new List<TurmaDisciplinaViewModel>();
    }
}
