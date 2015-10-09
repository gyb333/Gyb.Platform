
using Gyb.Design.Client.ODataProxy.Default;
using Gyb.FrameWork.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Client.ODataProxy
{
    public class ContainerFactory
    {
        
        private ContainerFactory()
        {

        }
 

        public static Container GetContainer()
        {            
            try
            {
                string serviceUri = ApplicationSettingsFactory.GetApplicationSettings().ServiceUri;
                var container = new Default.Container(new Uri(serviceUri));
                return container;
            }
            catch (Exception ex)
            {
                throw new Exception("GetContainer:" + ex.ToString());
            }
        }
    }
}
