using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Client.IServices
{
    public interface IBaseService<T>
    {
        ObservableCollection<T> GetData();

        void Save();

        void Delete(ObservableCollection<T> sourse);

        void Add(T model);
    }
}
