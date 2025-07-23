namespace ResponsavelAluno.Models.Entities
{
    using System;
    using EscolaPlus.Models.Entities;
    using ResponsavelEntity = Responsavel.Models.Entities.Responsavel;


    public class ResponsavelAluno
    {
        public int Id { get; set; }
        public int ResponsavelId { get; set; }
        public ResponsavelEntity Responsavel { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

    }
}