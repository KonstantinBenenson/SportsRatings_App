using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SportsRatings.Caching.DistributedCache
{
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// A method puts a new element to the Redic-cache-DataBase.
        /// Required parameters are a Key, Data, 
        /// optionally Absolute Expiration time (if no time indicated, sets a default of 10 minutes)
        /// and Slidint Expiration time (if no time indicated, remains as Null).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="recordId"></param>
        /// <param name="data"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        public static async Task CreateRecordAsync<T>(this IDistributedCache cache,
            string recordId,
            T data,
            TimeSpan? absoluteExpiration = null,
            TimeSpan? slidingExpiration = null)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromMinutes(10);
            options.SlidingExpiration = slidingExpiration;

            var output = JsonSerializer.Serialize(data);

            await cache.SetStringAsync(recordId, output, options); 
        }

        /// <summary>
        /// A method tries to get an element from Redis-cached-DataBase with provided key.
        /// In case of nothing found - returns a default value of the Type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache,
            string recordId)
        {
            var data = await cache.GetStringAsync(recordId);

            if (data == null) { return default(T); }

            return JsonSerializer.Deserialize<T>(data);
        }

    }
}
