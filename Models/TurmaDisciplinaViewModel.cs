public class TurmaDisciplinaViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Ano { get; set; }
    public string Serie { get; set; }
    public string Turno { get; set; }
    public int QuantidadeAlunos { get; set; }
    public int QuantidadeDisciplinas { get; set; }
    public int QuantidadeProfessores { get; set; }

    public int TurmaId { get; set; }
    public Turma Turma { get; set; }

    public int DisciplinaId { get; set; }
    public Disciplina Disciplina { get; set; }

    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }
}