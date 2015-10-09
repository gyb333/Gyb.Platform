using Gyb.Design.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Client.IServices
{
    public interface ITypeService
    {
        IQueryable<TypeBase> GetAllTypes();

    }
}
