using System.Collections.Generic;

namespace Api.Architecture.Web.VM.Common
{
    public class ResultServiceVM
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ResultServiceVM()
        {
            this.Messages = new List<string>();
            this.SuccessMessage = null;
        }

        /// <summary>
        /// Operation Result Validation
        /// </summary>
        public bool Success
        {
            get
            {
                return this.Messages.Count == 0;
            }
        }
        /// <summary>
        /// Error Messages
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// Success Message
        /// </summary>
        public string SuccessMessage { get; set; }
    }
}
