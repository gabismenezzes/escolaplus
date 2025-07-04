public class Aluno {
    public int Id { get; set;}
    public string NomeMae { get; set;}
    public string NomePai { get; set;}
    public string Naturalidade { get; set;}
    public string Nacionalidade { get; set;}
    public string Endereco { get; set;}
    public string Telefone { get; set;}
    public string ProfissaoMae { get; set;}
    public string ProfissaoPai { get; set;}
    public string ContatoResponsavel { get; set;}
    public int NumeroRG { get; set;}
    public string OrgaoEmissor { get; set;}
    public string CPF { get; set;}
    public boolean DoencasPreexistentes { get; set;}
    public string Doencas { get; set;}
    public boolean Alergias { get; set;}
    public string Alergias { get; set;}
    public boolean Medicamentos { get; set;}
    public string Medicamentos { get; set;}
    public string Observacoes { get; set;}
    public DateTime DataNascimento { get; set;}
    public Serie Serie {get; set;}
    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
    public int? TurmaId { get; set; }
    public Turma Turma { get; set; }
}