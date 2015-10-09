using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Cache
{
    public abstract class HttpContextCacheAdapter : ICacheStorage
    {
        //public void Remove(string key)
        //{
        //    HttpContext.Current.Cache.Remove(key);
        //}

        //public void Store(string key, object data)
        //{
        //    HttpContext.Current.Cache.Insert(key, data);
        //}

        //public T Retrieve<T>(string key)
        //{
        //    T itemStored = (T)HttpContext.Current.Cache.Get(key);
        //    if (itemStored == null)
        //        itemStored = default(T);

        //    return itemStored;
        //}       
        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object data)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object data, TimeSpan slidingExpiration)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            throw new NotImplementedException();
        }

        public T Retrieve<T>(string key)
        {
            throw new NotImplementedException();
        }
    }
}
