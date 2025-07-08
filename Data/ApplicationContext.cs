using Microsoft.EntityFrameworkCore;
using EscolaPlus.Models.Entities; // Onde está Usuario, Aluno, Nota, etc.
using ResponsavelAlunoEntity = ResponsavelAluno.Models.Entities.ResponsavelAluno;
using ResponsavelEntity = Responsavel.Models.Entities.Responsavel;
using ProfessorEntity = Professor.Models.Entities.Professor;
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
        public DbSet<ProfessorEntity> Professores { get; set; }
        public DbSet<TurmaEntity> Turmas { get; set; }
        public DbSet<DisciplinaEntity> Disciplinas { get; set; }
        public DbSet<AtividadeEntity> Atividade { get; set; }
        public DbSet<Comunicado> Comunicado { get; set; }
        public DbSet<EventoCalendarioEntity> EventoCalendario { get; set; }
        public DbSet<NotaEntity> Notas { get; set; }
        public DbSet<ResponsavelAlunoEntity> ResponsavelAluno { get; set; }
        public DbSet<ResponsavelEntity> Responsavel { get; set; }
    }
}
