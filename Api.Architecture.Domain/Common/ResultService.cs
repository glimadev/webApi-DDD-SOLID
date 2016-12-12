using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Api.Architecture.Domain.Common
{
    public class ResultService
    {
        /// <summary>
        /// Constructor with Fluent Validation
        /// </summary>
        public ResultService(ValidationResult fluentResult)
        {
            this.Messages = fluentResult.Errors.Select(x => x.ErrorMessage).ToList();
        }

        /// <summary>
        /// Constructor Empty
        /// </summary>
        public ResultService()
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
