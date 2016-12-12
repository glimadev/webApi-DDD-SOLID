
namespace Api.CenarioCapital.Infrastructure.Identity.Model.Enum
{
    public static class RoleConst
    {
        public const string Master = "Admin";
        public const string CenarioCapital = "CenarioCapital";
        public const string Manager = "Manager";
        public const string Seller = "User";

        public const string CenarioCapitalId = "167c0b5c-b3de-4d75-b568-e2744d075c2b";
    }

    public enum TypeUser
    {
        Cenario,
        Master,
        Manager,
        Seller,
        Unknown
    }
}
