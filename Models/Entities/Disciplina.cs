namespace Disciplina.Models.Entities
{
    using System.Collections.Generic;
    using EscolaPlus.Models;
    using EnumSerie = EscolaPlus.Models.Enums.Serie;
    using TurmaDisciplina = TurmaDisciplina.Models.Entities.TurmaDisciplina;
    using ProfessorDisciplina = EscolaPlus.Models.ViewModels.ProfessorDisciplina;
    using AlunoDisciplinaViewModel = EscolaPlus.Models.ViewModels.AlunoDisciplinaViewModel;
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int CargaHoraria { get; set; }
        public int SerieId { get; set; }
        public EnumSerie Serie { get; set; }
        public string SerieNome => Serie.ToString();

        public ICollection<TurmaDisciplina> TurmasDisciplinas { get; set; }
        public ICollection<ProfessorDisciplina> ProfessoresDisciplinas { get; set; }
        public ICollection<AlunoDisciplinaViewModel> AlunosDisciplinas { get; set; }
    }
}