using CadastroPessoa.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.Domain.Models
{
    public class Pessoa
    {
        public long Id { get;private set; }

        public TipoPessoa Tipo { get; private set; }

        public TipoSexo Sexo { get; private set; }

        public string? Nome { get; private set; }

        public string? RazaoSocial { get; private set; }

        public string? NomeSocial { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string? CPF { get; private set; }
        public string? RG { get; private set; }

        public string? CNPJ { get; private set; }

        public string? InscricaoEstadual { get; private set; }

        public string? InscricaoMunicipal { get; private set; }

        public bool Ativo { get; private set; }

        public string? Observacoes { get; private set; }


        public Pessoa(TipoPessoa tipo, TipoSexo sexo, string? nome, string? razaoSocial,
                      string? nomeSocial, DateTime dataNascimento, string? cPF, string? rG, string? cNPJ, string? inscricaoEstadual, 
                      string? inscricaoMunicipal, bool ativo, string? observacoes)
        {

            ValidateDomain(Tipo,Sexo,Nome,RazaoSocial,NomeSocial,DataNascimento,CPF,RG,CNPJ,
                           InscricaoEstadual,InscricaoMunicipal,Ativo,Observacoes);
        }
        public Pessoa(long id, TipoPessoa tipo, TipoSexo sexo, string? nome, string? razaoSocial,
                      string? nomeSocial, DateTime dataNascimento, string? cPF, string? rG, string? cNPJ, string? inscricaoEstadual,
                      string? inscricaoMunicipal, bool ativo, string? observacoes)
        {
            DomainExceptionValidation.When(id < 0, "O ID não pode ser negativo.");
            Id = id;
            ValidateDomain(Tipo, Sexo, Nome, RazaoSocial, NomeSocial, DataNascimento, CPF, RG, CNPJ,
                           InscricaoEstadual, InscricaoMunicipal, Ativo, Observacoes);
        }
        public void Update(TipoPessoa tipo, TipoSexo sexo, string? nome, string? razaoSocial,
                      string? nomeSocial, DateTime dataNascimento, string? cPF, string? rG, string? cNPJ, string? inscricaoEstadual,
                      string? inscricaoMunicipal, bool ativo, string? observacoes)
        {
            ValidateDomain(Tipo, Sexo, Nome, RazaoSocial, NomeSocial, DataNascimento, CPF, RG, CNPJ,
                           InscricaoEstadual, InscricaoMunicipal, Ativo, Observacoes);
        }
        public void ValidateDomain(TipoPessoa tipo, TipoSexo sexo, string? nome, string? razaoSocial,
                      string? nomeSocial, DateTime dataNascimento, string? cPF, string? rG, string? cNPJ, string? inscricaoEstadual,
                      string? inscricaoMunicipal, bool ativo, string? observacoes)
        {
            DomainExceptionValidation.When(nome.Length >100, "O Nome não pode ter mais que 100 caracteres.");
            DomainExceptionValidation.When(nome.Length < 3, "Tamanho mínimo do Nome é de 3 caracteres");
            DomainExceptionValidation.When(razaoSocial.Length > 100, "Tamanho máximo da Razão Social é de 100 caracteres");
            DomainExceptionValidation.When(nomeSocial.Length > 100, "Tamanho máximo do Nome Social é de 100 caracteres");
            DomainExceptionValidation.When(cPF.Length != 11, "Tamanho do CPF é de 11 caracteres.");
            DomainExceptionValidation.When(rG.Length != 9, "Tamanho do RG é de 9 caracteres.");
            DomainExceptionValidation.When(cNPJ.Length != 14, "Tamanho do CNPJ é de 14 caracteres.");
            DomainExceptionValidation.When(inscricaoEstadual.Length > 100, "Não pode ter mais que 100 caracteres.");
            DomainExceptionValidation.When(inscricaoMunicipal.Length > 100, "Não pode ter mais que 100 caracteres.");

            Tipo = tipo;
            Sexo = sexo;
            Nome = nome;
            RazaoSocial = razaoSocial;
            NomeSocial = nomeSocial;
            DataNascimento = dataNascimento;
            CPF = cPF;
            RG = rG;
            CNPJ = cNPJ;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            Ativo = ativo;
            Observacoes = observacoes;
        }
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

