using System;

namespace Api.Architecture.Infra.Data.Models
{
    public partial class Client : Entity
    {
        public Client()
        {
			this.Name = null;
			this.PreviousName = null;
			this.Cpf = null;
			this.Cnpj = null;
			this.Type = null;
			this.FantasyName = null;
			this.Nire = null;
			this.Cnae = null;
			this.ContractDescription = null;
			this.Class = null;
			this.ClassNumber = null;
			this.CityInscription = null;
			this.StateInscription = null;
			this.Address = null;
			this.AddressNumber = null;
			this.Complement = null;
			this.Neighborhood = null;
			this.Cep = null;
			this.City = null;
			this.State = null;
			this.Phone = null;
			this.Fax = null;
			this.Email = null;
        }

        public int ClientId { get; private set; }
		
        public int ClientTypeId { get; private set; }
		
        public int CompanyType { get; private set; }
		
        public string Name { get; private set; }
		
        public string PreviousName { get; private set; }
		
        public string Cpf { get; private set; }
		
        public string Cnpj { get; private set; }
		
        public Nullable<bool> Type { get; private set; }
		
        public string FantasyName { get; private set; }
		
        public string Nire { get; private set; }
		
        public string Cnae { get; private set; }
		
        public string ContractDescription { get; private set; }
		
        public string Class { get; private set; }
		
        public Nullable<int> ClassNumber { get; private set; }
		
        public string CityInscription { get; private set; }
		
        public string StateInscription { get; private set; }
		
        public string Address { get; private set; }
		
        public Nullable<int> AddressNumber { get; private set; }
		
        public string Complement { get; private set; }
		
        public string Neighborhood { get; private set; }
		
        public string Cep { get; private set; }
		
        public string City { get; private set; }
		
        public string State { get; private set; }
		
        public string Phone { get; private set; }
		
        public string Fax { get; private set; }
		
        public string Email { get; private set; }
    }
}
