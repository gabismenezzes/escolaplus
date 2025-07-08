namespace EscolaPlus.Models.Entities
{

    using Turma = Turma.Models.Entities.Turma;
    using Disciplina = Disciplina.Models.Entities.Disciplina;
    public class Atividade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrega { get; set; }
        public int DisciplinaId { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}