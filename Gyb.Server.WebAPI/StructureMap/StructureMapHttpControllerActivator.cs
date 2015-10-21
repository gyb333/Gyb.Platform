using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Gyb.Server.WebAPI
{
    public class StructureMapHttpControllerActivator : IHttpControllerActivator
    {
   public IContainer  Container { get; private set; }

   public StructureMapHttpControllerActivator(IContainer container)
     {        
         this.Container = container;
     }
  
     public  IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
     {
         return (IHttpController)this.Container.GetInstance(controllerType);
     }
    }
}