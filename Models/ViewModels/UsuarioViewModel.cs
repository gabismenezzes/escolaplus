namespace EscolaPlus.Models{
public class UsuarioViewModel
{
    public int Id { get; set; }
    public string Matricula { get; set;}
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario TipoUsuario { get; set; } 
}
}