using CacheCow.Server;
using Gyb.Server.Entities;
using Newtonsoft.Json.Serialization;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Gyb.Server.WebAPI
{
    public static class WebApiConfig
    {
        /// <summary>
        /// 返回对象时出现循环依赖,返回了领域模型中所有的字段给客户端，然而有一些敏感信息不应该返回（例如：password字段）
        /// 每一个返回给客户端的资源都应该包含一个URI以便客户端查询
        /// 对于返回单个资源，我们应当返回相应的状态码（例如：成功200，资源未找到404等）HttpResponseMessage对象
        /// 配置Json格式。
        /// 如何实现资源缓存HTTP缓存
        /// 由于不同的web服务器需要共享缓存状态，因此我们需要把缓存状态持久化到一个单独的地方（SQL Server, MongoDB, MemCache）。
        /// 但是在实现持久化之前我们先测试一下内存缓存。
        /// ETag是服务器为特定资源生成的一个唯一标识（string类型）。你也可以理解为用来检查服务器资源是否变化。
        ///ETag分2种类型：强类型和弱类型。对于弱类型的ETag包含一个前缀W（例如：W/53fsfsd322），而强类型的ETag不包含任何前缀（例如：53fsfsd322）。
        ///通常来说，弱类型ETag代表缓存短时间资源（内存缓存），而强类型的ETag缓存是靠持久化的方式来实现的。
        ///使用消息处理程序在客户端和服务器拦截请求和响应,应用缓存逻辑和规则。
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            //// Web API 配置和服务
            FormatterConfig.RegisterFormatters(config);

            ODataConfig.Register(config);

            RouteConfig.RegisterRoutes(config);

            FilterConfig.RegisterGlobalFilters(config);
            
            CacheCowConfig.RegisterCacheCow(config);            

            IContainer container = BootStrapper.GetConfiguredContainer();

            DependencyResolverConfig.RegisterDependencyResolver(config, container);     //注册依赖注入

            ActivatorConfig.RegisterActivators(config, container);

            SelectorConfig.RegisterSelector(config);            //注册控制选择器

        }
    }
}
