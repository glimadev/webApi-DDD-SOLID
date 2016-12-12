using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Api.Architecture.Infra.Data.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.PreviousName)
                .HasMaxLength(200);

            this.Property(t => t.Cpf)
                .HasMaxLength(15);

            this.Property(t => t.Cnpj)
                .HasMaxLength(20);

            this.Property(t => t.FantasyName)
                .HasMaxLength(150);

            this.Property(t => t.Nire)
                .HasMaxLength(150);

            this.Property(t => t.Cnae)
                .HasMaxLength(150);

            this.Property(t => t.Class)
                .HasMaxLength(150);

            this.Property(t => t.CityInscription)
                .HasMaxLength(150);

            this.Property(t => t.StateInscription)
                .HasMaxLength(150);

            this.Property(t => t.Address)
                .HasMaxLength(255);

            this.Property(t => t.Complement)
                .HasMaxLength(255);

            this.Property(t => t.Neighborhood)
                .HasMaxLength(255);

            this.Property(t => t.Cep)
                .HasMaxLength(10);

            this.Property(t => t.City)
                .HasMaxLength(150);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Phone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Clients");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ClientTypeId).HasColumnName("ClientTypeId");
            this.Property(t => t.CompanyType).HasColumnName("CompanyType");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PreviousName).HasColumnName("PreviousName");
            this.Property(t => t.Cpf).HasColumnName("Cpf");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.EditedDate).HasColumnName("EditedDate");
            this.Property(t => t.DeletedDate).HasColumnName("DeletedDate");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.FantasyName).HasColumnName("FantasyName");
            this.Property(t => t.Nire).HasColumnName("Nire");
            this.Property(t => t.Cnae).HasColumnName("Cnae");
            this.Property(t => t.ContractDescription).HasColumnName("ContractDescription");
            this.Property(t => t.Class).HasColumnName("Class");
            this.Property(t => t.ClassNumber).HasColumnName("ClassNumber");
            this.Property(t => t.CityInscription).HasColumnName("CityInscription");
            this.Property(t => t.StateInscription).HasColumnName("StateInscription");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.AddressNumber).HasColumnName("AddressNumber");
            this.Property(t => t.Complement).HasColumnName("Complement");
            this.Property(t => t.Neighborhood).HasColumnName("Neighborhood");
            this.Property(t => t.Cep).HasColumnName("Cep");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
