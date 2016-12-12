using System.Collections.Generic;
using Api.Architecture.Web.VM.Common;

namespace Api.Architecture.Web.VM.Out
{
    public class UserGetAllNamesOutVM : ResultServiceVM
    {
        public UserGetAllNamesOutVM()
        {
            this.Names = new List<string>();
        }

        public List<string> Names { get; set; }
    }
}
