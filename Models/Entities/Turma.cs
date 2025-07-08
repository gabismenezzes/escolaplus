using EscolaPlus.Models.Entities;

namespace Turma.Models.Entities
{
    public class Turma
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int AnoLetivo { get; set; }

    public ICollection<Aluno> Alunos { get; set; }
    public ICollection<TurmaDisciplina.Models.Entities.TurmaDisciplina> Disciplinas { get; set; }

    }
}