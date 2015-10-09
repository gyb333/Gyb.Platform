using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Cache
{
    public abstract class SystemRuntimeCacheStorage : ICacheStorage
    {
        //public void Remove(string key)
        //{
        //    ObjectCache cache = MemoryCache.Default;
        //    cache.Remove(key);
        //}

        //public void Store(string key, object data)
        //{
        //    ObjectCache cache = MemoryCache.Default;
        //    cache.Add(key, data, null);
        //}

        //public void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        //{
        //    ObjectCache cache = MemoryCache.Default;
        //    var policy = new CacheItemPolicy
        //    {
        //        AbsoluteExpiration = absoluteExpiration,
        //        SlidingExpiration = slidingExpiration
        //    };

        //    if (cache.Contains(key))
        //    {
        //        cache.Remove(key);
        //    }

        //    cache.Add(key, data, policy);
        //}

        //public T Retrieve<T>(string key)
        //{
        //    ObjectCache cache = MemoryCache.Default;
        //    return cache.Contains(key) ? (T)cache[key] : default(T);
        //}

        //public void Store(string key, object data, TimeSpan slidingExpiration)
        //{
        //    ObjectCache cache = MemoryCache.Default;
        //    var policy = new CacheItemPolicy
        //    {
        //        SlidingExpiration = slidingExpiration
        //    };

        //    if (cache.Contains(key))
        //    {
        //        cache.Remove(key);
        //    }

        //    cache.Add(key, data, policy);
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
