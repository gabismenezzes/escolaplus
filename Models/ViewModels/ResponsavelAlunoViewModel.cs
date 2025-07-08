namespace EscolaPlus.Models.ViewModels{
public class ResponsavelAlunoViewModel
{
    public int ResponsavelId { get; set; }
    public ResponsavelViewModel Responsavel { get; set; }

    public int AlunoId { get; set; }
    public AlunoViewModel Aluno { get; set; }
}
}