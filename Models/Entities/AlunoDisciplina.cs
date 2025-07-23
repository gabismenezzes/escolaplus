namespace EscolaPlus.Models.ViewModels
{
    public class AlunoDisciplinaViewModel
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public int DisciplinaId { get; set; }
        public string NomeDisciplina { get; set; }
        // outros campos que você quiser exibir
    }
}