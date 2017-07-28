using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace CRM.Infrastructure
{
    public class CacheLayer
    {
        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {

            try
            {
                return (T)WebCache.Get(key);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        public static void Add<T>(T objectToCache, string key) where T : class
        {
            WebCache.Set(key, objectToCache, 30, false);
        }
        public static void Add<T>(T objectToCache, string key, int minute) where T : class
        {
            WebCache.Set(key, objectToCache, minute, false);
        }
        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        public static void Add(object objectToCache, string key)
        {
            WebCache.Set(key, objectToCache, 30, false);
        }
        public static void Add(object objectToCache, string key, int minute)
        {
            WebCache.Set(key, objectToCache, minute, false);
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            WebCache.Remove(key);
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return WebCache.Get(key) != null;
        }
    }
}
