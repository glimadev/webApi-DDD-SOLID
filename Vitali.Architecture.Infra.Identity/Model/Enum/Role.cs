using System.ComponentModel;

namespace Api.CenarioCapital.Infrastructure.Identity.Model.Enum
{
    public enum Role
    {
        [Description(RoleConst.Master)]
        Admin = 0,
        [Description(RoleConst.CenarioCapital)]
        CenarioCapital = 1,
        [Description(RoleConst.Manager)]
        Manager = 2,
        [Description(RoleConst.Seller)]
        User = 3
    }
}