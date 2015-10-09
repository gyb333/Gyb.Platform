using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.IRepository
{
    public interface IBaseRepository
    {
        string GetServerNO();

        string GetServerIP();

        string GetServerHostName();

        DateTime GetServerDateTime();
    }
}
