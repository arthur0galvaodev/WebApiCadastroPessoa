using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoa.Models
{
    public class Pessoa
    {
        public long Id { get; set; }

        public Guid UUId { get; set; } = Guid.NewGuid();

        public TipoPessoa Tipo { get; set; }

        public TipoSexo Sexo { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeSocial { get; set; }

        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        public string? CPF { get; set; }
        [Column(TypeName = "VARCHAR(9)")]
        public string? RG { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? InscricaoEstadual { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? InscricaoMunicipal { get; set; }

        public bool Ativo { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string? Observacoes { get; set; }

        public long UUAId { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; } = DateTime.Now;
    }
    public enum TipoPessoa
    {
        Fisica = 1,
        Juridica = 2,
        ProdutorRural = 3
    }

    public enum TipoSexo
    {
        Masculino = 1,
        Feminino = 2,
        Outros = 3
    }
}
