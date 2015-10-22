using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Gyb.Server.WebAPI.StructureMap
{
    /// <summary>
    /// 获取过滤器
    /// </summary>
    public class StructureMapFilterProvider : IFilterProvider
    {
        private IContainer _container;
        public StructureMapFilterProvider(IContainer container)
        {
            _container = container;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var controllerFilters = actionDescriptor.ControllerDescriptor.GetFilters().Select(instance => new FilterInfo(instance, FilterScope.Controller));
            var actionFilters = actionDescriptor.GetFilters().Select(instance => new FilterInfo(instance, FilterScope.Action));

            var filters = controllerFilters.Concat(actionFilters);

            foreach (var f in filters)
            {
                // Injection
                _container.Inject(f.Instance);
            }

            return filters;
        }
    }
}