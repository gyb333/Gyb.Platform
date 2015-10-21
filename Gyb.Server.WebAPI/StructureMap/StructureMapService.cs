﻿using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Gyb.Server.WebAPI
{
    public class StructureMapService : IDependencyScope
    {
        protected IContainer Container;
  
          public StructureMapService(IContainer container)
          {
              Container = container;
          }
  
          public void Dispose()
          {
              IDisposable disposable = (IDisposable)Container;
              if (disposable != null)
              {
                  disposable.Dispose();
              }
              Container = null;
          }
  
          public object GetService(Type serviceType)
          {
              if (serviceType == null)
              {
                  return null;
              }
              try
              {
                  if (serviceType.IsAbstract || serviceType.IsInterface)
                      return Container.TryGetInstance(serviceType);
  
                  return Container.GetInstance(serviceType);
              }
              catch
              {
                  return null;
              }
          }
  
          public IEnumerable<object> GetServices(Type serviceType)
          {
              return Container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
          }
    }
}