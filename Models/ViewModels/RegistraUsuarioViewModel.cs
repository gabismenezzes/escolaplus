using System.ComponentModel.DataAnnotations;
using EscolaPlus.Models.ViewModels;

namespace EscolaPlus.Models.ViewModels
{
    public class RegistraUsuarioViewModel
    {
        [Required(ErrorMessage = "Selecione o tipo de usuário")]
        public string UserType { get; set; }

        public ProfessorViewModel Professor { get; set; } = new ProfessorViewModel();
        public AlunoViewModel Aluno { get; set; } = new AlunoViewModel();
        public UsuarioViewModel Diretor { get; set; } = new UsuarioViewModel();
    }
}