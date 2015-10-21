using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Web.Http.Controllers;
using System.Security.Principal;

namespace Gyb.Server.WebAPI.filters
{
    public class Base64AuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //forms authentication Case that user is authenticated using forms authentication
            //so no need to check header for basic authentication.
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return;
            }

            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                    !String.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    var credArray = GetCredentials(authHeader);
                    var userName = credArray[0];
                    var password = credArray[1];

                    if (IsResourceOwner(userName, actionContext))
                    {
                        //You can use Websecurity or asp.net memebrship provider to login, for
                        //for he sake of keeping example simple, we used out own login functionality

                        //if (TheRepository.LoginStudent(userName, password))
                        {
                            var currentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                            Thread.CurrentPrincipal = currentPrincipal;
                            return;
                        }
                    }
                }
            }

            HandleUnauthorizedRequest(actionContext);
        }

        private string[] GetCredentials(AuthenticationHeaderValue authHeader)
        {

            //Base 64 encoded string
            var rawCred = authHeader.Parameter;
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var cred = encoding.GetString(Convert.FromBase64String(rawCred));

            var credArray = cred.Split(':');

            return credArray;
        }

        private bool IsResourceOwner(string userName, HttpActionContext actionContext)
        {
            var routeData = actionContext.Request.GetRouteData();
            var resourceUserName = routeData.Values["userName"] as string;

            if (resourceUserName == userName)
            {
                return true;
            }
            return false;
        }

        private void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='eLearning' location='http://localhost:60914/account/login'");

        }


    }
}