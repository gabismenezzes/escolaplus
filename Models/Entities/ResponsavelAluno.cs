using System;
using EscolaPlus.Models.Entities;

namespace EscolaPlus.Models.Entities
{
    public class ResponsavelAluno
    {
        public int Id { get; set; }
        public int ResponsavelId { get; set; }
        public Responsavel Responsavel { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}