namespace EscolaPlus.Models.ViewModels{
public class ResponsavelViewModel {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Celular { get; set; }
    public string Endereco { get; set; }
    public string Profissao { get; set; }
    public string Empresa { get; set; }
    public string Cargo { get; set; }
    public DateTime DataNascimento { get; set; }
    public ICollection<ResponsavelAlunoViewModel> Alunos { get; set; } = new List<ResponsavelAlunoViewModel>();
}
}