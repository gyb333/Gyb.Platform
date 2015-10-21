using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;


namespace Gyb.Server.WebAPI.filters
{
    /// <summary>
    /// Action方法都要求在一个安全上下文中被执行
    /// 使用了Http的Get请求来访问资源，使用https创建一个连接并添加在响应Header的Location中。客户端就会自动使用https来发送Get请求
    /// </summary>
    public class ForceHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
             var request = actionContext.Request;

             if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
             {
                 var html = "<p>Https is required</p>";

                 if (request.Method.Method == "GET")
                 {
                     actionContext.Response = request.CreateResponse(HttpStatusCode.Found);
                     actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");

                     UriBuilder httpsNewUri = new UriBuilder(request.RequestUri);
                     httpsNewUri.Scheme = Uri.UriSchemeHttps;
                     httpsNewUri.Port = 443;

                     actionContext.Response.Headers.Location = httpsNewUri.Uri;
                 }
                 else
                 {
                     actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
                     actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");
                 }
             }
        }
    }
}