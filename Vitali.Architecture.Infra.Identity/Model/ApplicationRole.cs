using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Api.Architecture.Infra.Identity.Model
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            this.Active = true;
            this.Deleted = false;
            this.CreatedDate = DateTime.Now;
        }

        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
