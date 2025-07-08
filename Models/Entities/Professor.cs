namespace Professor.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using EscolaPlus.Models.Entities;
    using UsuarioEntity = EscolaPlus.Models.Entities.Usuario;



    public class Professor
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FormacaoAcademica { get; set; }
        public string Observacoes { get; set; }

        public UsuarioEntity Usuario { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<Turma.Models.Entities.Turma> Turmas { get; set; }
        public ICollection<Disciplina.Models.Entities.Disciplina> Disciplinas { get; set; }
        public ICollection<Atividade> Atividades { get; set; }
    }
}