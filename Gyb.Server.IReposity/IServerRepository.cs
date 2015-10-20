using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.IRepository
{
    public interface IServerRepository
    {
        string GetServerNO();

        string GetServerIP();

        string GetServerHostName();

        DateTime GetServerDateTime();
    }
}
