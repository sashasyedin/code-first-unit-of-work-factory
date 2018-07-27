using Quizmaster.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quizmaster.Common.Models
{
    /// <summary>
    /// Base class for response classes.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class Response<TResult>
        where TResult : struct, IConvertible
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public TResult Result { get; set; }

        /// <summary>
        /// Gets the result message.
        /// </summary>
        /// <value>
        /// The result message.
        /// </value>
        public string ResultMessage
        {
            get
            {
                if (this.Result is Enum)
                {
                    var resultDisplayName = (this.Result as Enum).GetAttribute<DisplayAttribute>();
                    return resultDisplayName.Name;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the response represents success.
        /// </summary>
        /// <value>
        /// <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success
        {
            get
            {
                if (this.Result is Enum)
                {
                    if ((this.Result as Enum).ToString() == "Success")
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
