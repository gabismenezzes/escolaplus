namespace Comunicados.Models.Entities
{
    using System;
    using EscolaPlus.Models.Entities;
    using Turma = Turma.Models.Entities.Turma;

    public class Comunicado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Comunicado()
        {
            DataPublicacao = DateTime.Now;
        }
    }
}