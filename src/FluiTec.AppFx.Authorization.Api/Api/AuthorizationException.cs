using System;
using System.Net.Http;

namespace FluiTec.AppFx.Authorization.Api.Api
{
    /// <summary>   Exception for signalling authorization errors. </summary>
    public class AuthorizationException : Exception
    {
        /// <summary>   Gets or sets the response. </summary>
        /// <value> The response. </value>
        public HttpResponseMessage Response { get; private set; }

        /// <summary>   Constructor. </summary>
        /// <param name="response"> The response. </param>
        public AuthorizationException(HttpResponseMessage response)
        {
            Response = response;
        }
    }
}