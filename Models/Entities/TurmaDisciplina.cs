using System;
using TurmaEntity = Turma.Models.Entities.Turma;
using ProfessorEntity = Professor.Models.Entities.Professor;
using DisciplinaEntity = Disciplina.Models.Entities.Disciplina;
using Disciplina.Models.Entities;

namespace TurmaDisciplina.Models.Entities
{
    public class TurmaDisciplina
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public int DisciplinaId { get; set; }
        public int ProfessorId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        // Relacionamento com Turma
        public TurmaEntity Turma { get; set; }

        // Relacionamento com Disciplina
        public DisciplinaEntity Disciplina { get; set; }

        // Relacionamento com Professor
        public ProfessorEntity Professor { get; set; }
    }
}
