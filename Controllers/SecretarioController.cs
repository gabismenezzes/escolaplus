using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EscolaPlus.Data;
using EscolaPlus.Models.Entities;
using EscolaPlus.Models.ViewModels;

namespace EscolaPlus.Controllers
{
    [Authorize(Roles = "Secretario")]
    public class SecretarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SecretarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Secretario/Index.cshtml");
        }

        [HttpGet]
        public IActionResult RegistraUsuario()
        {
            var model = new RegistraUsuarioViewModel();
            return View("~/Views/Home/Secretario/RegistraUsuario.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistraUsuario(RegistraUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            switch (model.UserType)
            {
                case "Professor":
                    if (model.Professor != null)
                    {
                        var usuarioProfessor = new Usuario
                        {
                            Matricula = $"PROF{DateTime.Now.Ticks}",
                            Nome = model.Professor.Nome,
                            Email = model.Professor.Email,
                            Senha = BCrypt.Net.BCrypt.HashPassword(model.Professor.Senha),
                            TipoUsuario = TipoUsuario.Professor
                        };

                        var professor = new Professor
                        {
                            Nome = model.Professor.Nome,
                            Email = model.Professor.Email,
                            DataNascimento = model.Professor.DataNascimento,
                            FormacaoAcademica = model.Professor.FormacaoAcademica,
                            Observacoes = model.Professor.Observacoes,
                            Usuario = usuarioProfessor
                        };

                        _context.Usuarios.Add(usuarioProfessor);
                        _context.Professores.Add(professor);
                    }
                    break;

                case "Aluno":
                    if (model.Aluno != null)
                    {
                        var usuarioAluno = new Usuario
                        {
                            Matricula = $"ALU{DateTime.Now.Ticks}",
                            Nome = model.Aluno.Nome,
                            Email = model.Aluno.Email,
                            Senha = BCrypt.Net.BCrypt.HashPassword(model.Aluno.Senha),
                            TipoUsuario = TipoUsuario.Aluno
                        };

                        var aluno = new Aluno
                        {
                            Nome = model.Aluno.Nome,
                            Email = model.Aluno.Email,
                            NomeMae = model.Aluno.NomeMae,
                            NomePai = model.Aluno.NomePai,
                            Naturalidade = model.Aluno.Naturalidade,
                            Nacionalidade = model.Aluno.Nacionalidade,
                            Endereco = model.Aluno.Endereco,
                            Telefone = model.Aluno.Telefone,
                            ProfissaoMae = model.Aluno.ProfissaoMae,
                            ProfissaoPai = model.Aluno.ProfissaoPai,
                            ContatoResponsavel = model.Aluno.ContatoResponsavel,
                            NumeroRG = int.TryParse(model.Aluno.NumeroRG, out var numeroRg) ? numeroRg : 0, // Convert string to int, default 0 if invalid
                            OrgaoEmissor = model.Aluno.OrgaoEmissor,
                            CPF = model.Aluno.CPF,
                            DoencasPreexistentes = model.Aluno.DoencasPreexistentes,
                            Doencas = model.Aluno.Doencas,
                            is_Alergias = model.Aluno.IsAlergias,
                            Alergias = model.Aluno.Alergias,
                            is_Medicamentos = model.Aluno.IsMedicamentos,
                            Medicamentos = model.Aluno.Medicamentos,
                            Observacoes = model.Aluno.Observacoes,
                            DataNascimento = model.Aluno.DataNascimento,
                            Serie = model.Aluno.Serie,
                            Usuario = usuarioAluno
                        };

                        var usuarioResponsavel = new Usuario
                        {
                            Matricula = $"RESP{DateTime.Now.Ticks}",
                            Nome = model.Aluno.ResponsavelNome,
                            Email = model.Aluno.ResponsavelEmail,
                            Senha = BCrypt.Net.BCrypt.HashPassword(model.Aluno.ResponsavelSenha),
                            TipoUsuario = TipoUsuario.Responsavel
                        };

                        var responsavel = new Responsavel
                        {
                            Nome = model.Aluno.ResponsavelNome,
                            Email = model.Aluno.ResponsavelEmail,
                            Telefone = model.Aluno.ResponsavelTelefone,
                            Celular = model.Aluno.ResponsavelCelular,
                            Endereco = model.Aluno.ResponsavelEndereco,
                            Profissao = model.Aluno.ResponsavelProfissao,
                            Empresa = model.Aluno.ResponsavelEmpresa,
                            Cargo = model.Aluno.ResponsavelCargo,
                            DataNascimento = model.Aluno.ResponsavelDataNascimento
                        };

                        var responsavelAluno = new ResponsavelAluno
                        {
                            Aluno = aluno,
                            Responsavel = responsavel
                        };

                        _context.Usuarios.Add(usuarioAluno);
                        _context.Alunos.Add(aluno);
                        _context.Usuarios.Add(usuarioResponsavel);
                        _context.Responsavel.Add(responsavel);
                        _context.ResponsavelAluno.Add(responsavelAluno);
                    }
                    break;

                case "Diretor":
                    if (model.Diretor != null)
                    {
                        var usuarioDiretor = new Usuario
                        {
                            Matricula = $"DIR{DateTime.Now.Ticks}",
                            Nome = model.Diretor.Nome,
                            Email = model.Diretor.Email,
                            Senha = BCrypt.Net.BCrypt.HashPassword(model.Diretor.Senha),
                            TipoUsuario = TipoUsuario.Administrador
                        };

                        _context.Usuarios.Add(usuarioDiretor);
                    }
                    break;

                default:
                    ModelState.AddModelError("UserType", "Tipo de usuário inválido.");
                    return View(model);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult RegisterProfessor()
        {
            return View(new ProfessorViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterProfessor(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Matricula = $"PROF{DateTime.Now.Ticks}",
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                    TipoUsuario = TipoUsuario.Professor
                };

                var professor = new Professor
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    DataNascimento = model.DataNascimento,
                    FormacaoAcademica = model.FormacaoAcademica,
                    Observacoes = model.Observacoes,
                    Usuario = usuario
                };

                _context.Usuarios.Add(usuario);
                _context.Professores.Add(professor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterAluno()
        {
            return View(new AlunoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterAluno(AlunoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuarioAluno = new Usuario
                {
                    Matricula = $"ALU{DateTime.Now.Ticks}",
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                    TipoUsuario = TipoUsuario.Aluno
                };

                var aluno = new Aluno
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    NomeMae = model.NomeMae,
                    NomePai = model.NomePai,
                    Naturalidade = model.Naturalidade,
                    Nacionalidade = model.Nacionalidade,
                    Endereco = model.Endereco,
                    Telefone = model.Telefone,
                    ProfissaoMae = model.ProfissaoMae,
                    ProfissaoPai = model.ProfissaoPai,
                    ContatoResponsavel = model.ContatoResponsavel,
                    NumeroRG = int.TryParse(model.NumeroRG, out var numeroRg) ? numeroRg : 0, // Convert string to int, default 0 if invalid
                    OrgaoEmissor = model.OrgaoEmissor,
                    CPF = model.CPF,
                    DoencasPreexistentes = model.DoencasPreexistentes,
                    Doencas = model.Doencas,
                    is_Alergias = model.IsAlergias,
                    Alergias = model.Alergias,
                    is_Medicamentos = model.IsMedicamentos,
                    Medicamentos = model.Medicamentos,
                    Observacoes = model.Observacoes,
                    DataNascimento = model.DataNascimento,
                    Serie = model.Serie,
                    Usuario = usuarioAluno
                };

                var usuarioResponsavel = new Usuario
                {
                    Matricula = $"RESP{DateTime.Now.Ticks}",
                    Nome = model.ResponsavelNome,
                    Email = model.ResponsavelEmail,
                    Senha = BCrypt.Net.BCrypt.HashPassword(model.ResponsavelSenha),
                    TipoUsuario = TipoUsuario.Responsavel
                };

                var responsavel = new Responsavel
                {
                    Nome = model.ResponsavelNome,
                    Email = model.ResponsavelEmail,
                    Telefone = model.ResponsavelTelefone,
                    Celular = model.ResponsavelCelular,
                    Endereco = model.ResponsavelEndereco,
                    Profissao = model.ResponsavelProfissao,
                    Empresa = model.ResponsavelEmpresa,
                    Cargo = model.ResponsavelCargo,
                    DataNascimento = model.ResponsavelDataNascimento,
                };

                var responsavelAluno = new ResponsavelAluno
                {
                    Aluno = aluno,
                    Responsavel = responsavel
                };

                _context.Usuarios.Add(usuarioAluno);
                _context.Alunos.Add(aluno);
                _context.Usuarios.Add(usuarioResponsavel);
                _context.Responsavel.Add(responsavel);
                _context.ResponsavelAluno.Add(responsavelAluno);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterDiretor()
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterDiretor(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Matricula = $"DIR{DateTime.Now.Ticks}",
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                    TipoUsuario = TipoUsuario.Administrador
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}