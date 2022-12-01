using Microsoft.Extensions.Caching.Memory;

namespace Helpers.Cache
{
    public class Cache : ICache
    {
        private readonly IMemoryCache _cache;
        public Cache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public T GetCache<T>(string key)
        {
            return _cache.Get<T>(key);
        }
        public void RemoveCache(string key)
        {
            _cache.Remove(key);
        }
        public void SetCache<T>(T value, string key, int minutesStored)
        {
            _cache.Set(key, value, DateTime.Now.AddMinutes(minutesStored));
        }
    }
}
