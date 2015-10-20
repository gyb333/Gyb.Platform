using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Client.IServices
{
    public interface IViewModelService
    {
        void InitCommand();

        void RegisterMessger();
    }
}
