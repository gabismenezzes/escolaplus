namespace EscolaPlus.Models.ViewModels{
public class NotaViewModel {
    public int Id { get; set; }
    public double Valor { get; set; }
    public int Trimestre { get; set; }
    public DateTime DataLancamento { get; set; }

    public int AlunoId { get; set; }
    public AlunoViewModel Aluno { get; set; }

    public int DisciplinaId { get; set; }
    public DisciplinaViewModel Disciplina { get; set; }
}
}