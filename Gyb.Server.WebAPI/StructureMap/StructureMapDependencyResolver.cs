using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Gyb.Server.WebAPI
{
    public class StructureMapDependencyResolver : StructureMapService, IDependencyResolver
    {
        private IContainer _container;
        public StructureMapDependencyResolver(IContainer container)
            :base(container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {   
             return new StructureMapService(_container);
        }
    }
}