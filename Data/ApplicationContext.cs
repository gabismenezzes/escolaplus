using Microsoft.EntityFrameworkCore;
using EscolaPlus.Models.Entities; 
using TurmaEntity = Turma.Models.Entities.Turma;
using DisciplinaEntity = Disciplina.Models.Entities.Disciplina;
using AtividadeEntity = EscolaPlus.Models.Entities.Atividade;
using Comunicados.Models.Entities;
using EventoCalendarioEntity = EventoCalendario.Models.Entities.EventoCalendario;
using NotaEntity = Nota.Models.Entities.Nota;

namespace EscolaPlus.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<TurmaEntity> Turmas { get; set; }
        public DbSet<DisciplinaEntity> Disciplinas { get; set; }
        public DbSet<AtividadeEntity> Atividade { get; set; }
        public DbSet<Comunicado> Comunicado { get; set; }
        public DbSet<EventoCalendarioEntity> EventoCalendario { get; set; }
        public DbSet<NotaEntity> Notas { get; set; }
        public DbSet<ResponsavelAluno> ResponsavelAluno { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
    }
}
