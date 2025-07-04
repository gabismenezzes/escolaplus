public class TurmaViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int AnoLetivo { get; set; }

    public ICollection<Aluno> Alunos { get; set; }
    public ICollection<TurmaDisciplina> Disciplinas { get; set; }
}
