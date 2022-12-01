namespace Helpers.Cache
{
    public interface ICache
    {
        T GetCache<T>(string key);
        void RemoveCache(string key);
        void SetCache<T>(T value, string key, int minutesStored);
    }
}
