namespace Nota.Models.Entities
{
    using System;
    using EscolaPlus.Models.Enums;
    using EscolaPlus.Models.ViewModels;
    using EscolaPlus.Models.Entities;
    using DisciplinaEntity = Disciplina.Models.Entities.Disciplina;

    public class Nota
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public int Trimestre { get; set; }
        public DateTime DataLancamento { get; set; }

        public int AlunoId { get; set; }
        public EscolaPlus.Models.Entities.Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }
        public DisciplinaEntity Disciplina { get; set; }
    }
}