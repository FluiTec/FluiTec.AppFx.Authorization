using System;
using System.Net.Http;

namespace FluiTec.AppFx.Authorization.Api.Api
{
    /// <summary>   Exception for signalling authorization errors. </summary>
    public class AuthorizationException : Exception
    {
        /// <summary>   Constructor. </summary>
        /// <param name="response"> The response. </param>
        public AuthorizationException(HttpResponseMessage response)
        {
            Response = response;
        }

        /// <summary>   Gets or sets the response. </summary>
        /// <value> The response. </value>
        public HttpResponseMessage Response { get; }
    }
}