namespace EventoCalendario.Models.Entities
{
    using System;
    using EscolaPlus.Models.Enums;
    using TurmaEntity = Turma.Models.Entities.Turma;
    using UsuarioEntity = EscolaPlus.Models.Entities.Usuario;

    public class EventoCalendario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int TurmaId { get; set; }
        public TurmaEntity Turma { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }
    }
}