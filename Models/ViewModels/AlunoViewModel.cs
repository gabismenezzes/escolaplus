using System;
using System.ComponentModel.DataAnnotations;
using EscolaPlus.Models.Enums;

namespace EscolaPlus.Models.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O nome da mãe é obrigatório")]
        public string NomeMae { get; set; }

        public string NomePai { get; set; }

        [Required(ErrorMessage = "A naturalidade é obrigatória")]
        public string Naturalidade { get; set; }

        [Required(ErrorMessage = "A nacionalidade é obrigatória")]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        public string ProfissaoMae { get; set; }

        public string ProfissaoPai { get; set; }

        [Required(ErrorMessage = "O contato do responsável é obrigatório")]
        public string ContatoResponsavel { get; set; }

        [Required(ErrorMessage = "O número do RG é obrigatório")]
        public string NumeroRG { get; set; }

        [Required(ErrorMessage = "O órgão emissor é obrigatório")]
        public string OrgaoEmissor { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        public bool DoencasPreexistentes { get; set; }

        public string Doencas { get; set; }

        public bool IsAlergias { get; set; }

        public string Alergias { get; set; }

        public bool IsMedicamentos { get; set; }

        public string Medicamentos { get; set; }

        public string Observacoes { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A série é obrigatória")]
        public Serie Serie { get; set; }

        // Responsavel Fields
        [Required(ErrorMessage = "O nome do responsável é obrigatório")]
        public string ResponsavelNome { get; set; }

        [Required(ErrorMessage = "O e-mail do responsável é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string ResponsavelEmail { get; set; }

        [Required(ErrorMessage = "A senha do responsável é obrigatória")]
        [DataType(DataType.Password)]
        public string ResponsavelSenha { get; set; }

        [Required(ErrorMessage = "O telefone do responsável é obrigatório")]
        public string ResponsavelTelefone { get; set; }

        public string ResponsavelCelular { get; set; }

        [Required(ErrorMessage = "O endereço do responsável é obrigatório")]
        public string ResponsavelEndereco { get; set; }

        public string ResponsavelProfissao { get; set; }

        public string ResponsavelEmpresa { get; set; }

        public string ResponsavelCargo { get; set; }

        [Required(ErrorMessage = "A data de nascimento do responsável é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime ResponsavelDataNascimento { get; set; }
    }
}