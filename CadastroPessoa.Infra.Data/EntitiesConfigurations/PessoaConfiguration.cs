using CadastroPessoa.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.Infra.Data.EntitiesConfigurations
{
    internal class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configuration(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.Nome).HasMaxLength(100).IsRequired();
            builder.Property(X => X.RazaoSocial).HasMaxLength(100);
            builder.Property(X => X.NomeSocial).HasMaxLength(100);
            builder.Property(X => X.CPF).HasMaxLength(11);
            builder.Property(X => X.RG).HasMaxLength(9);
            builder.Property(X => X.CNPJ).HasMaxLength(14);
            builder.Property(X => X.InscricaoEstadual).HasMaxLength(50);
            builder.Property(X => X.InscricaoMunicipal).HasMaxLength(50);
        }

        void IEntityTypeConfiguration<Pessoa>.Configure(EntityTypeBuilder<Pessoa> builder)
        {
            throw new NotImplementedException();
        }
    }
}
