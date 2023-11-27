using CadastroPessoa.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoa.DTOs
{
    public class PessoaDTO
    {
        public long Id { get; set; }
        public Guid UUId { get; set; } = Guid.NewGuid();
        public TipoPessoa Tipo { get; set; }
        public TipoSexo Sexo { get; set; }
        [StringLength(100, ErrorMessage = "Tamanho máximo do Nome é de 100 caracteres")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo do Nome é de 3 caracteres")]
        public string? Nome { get; set; }
        [StringLength(100, ErrorMessage = "Tamanho máximo da Razão Social é de 100 caracteres")]
        public string? RazaoSocial { get; set; }
        [StringLength(100, ErrorMessage = "Tamanho máximo do Nome Social é de 100 caracteres")]
        public string? NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        [StringLength(11, ErrorMessage = "Tamanho máximo do CPF é de 11 caracteres")]
        [MinLength(11, ErrorMessage = "Tamanho mínimo do CPF é de 11 caracteres")]
        public string? CPF { get; set; }
        [StringLength(9, ErrorMessage = "Tamanho máximo para o RG é de 9 caracteres")]
        [MinLength(9, ErrorMessage = "Tamanho mínimo para o RG é de 9 caracteres")]
        public string? RG { get; set; }
        [StringLength(14, ErrorMessage = "Tamanho máximo para o CNPJ é de 14 caracteres")]
        [MinLength(14, ErrorMessage = "Tamanho mínimo para o CNPJ é de 14 caracteres")]
        public string? CNPJ { get; set; }
        [StringLength(50, ErrorMessage = "Tamanho máximo e de 100 caracteres")]
        public string? InscricaoEstadual { get; set; }
        [StringLength(50, ErrorMessage = "Tamanho máximo e de 100 caracteres")]
        public string? InscricaoMunicipal { get; set; }

        public bool Ativo { get; set; }

    }
}
