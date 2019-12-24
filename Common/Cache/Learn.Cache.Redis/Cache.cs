using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
namespace Learn.Cache.Redis
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2016.04.28 10:45
    /// 描 述：定义缓存接口
    /// </summary>
    public class Cache : ICache
    {

        private readonly IRedisCacheManager _cache;
        public Cache(IRedisCacheManager cache)
        {
            _cache = cache;
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey)
        {
            return _cache.Get<T>(cacheKey);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void AddCache<T>(string cacheKey,T value) 
        {
            //RedisCache.Set(cacheKey, value);
            //配置成与webcache相同时间
            _cache.Set(cacheKey, value, TimeSpan.FromHours(2));
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void AddCache<T>(string cacheKey, T value, DateTime expireTime) 
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            TimeSpan expireTimeSpan = new TimeSpan((long)(expireTime - startTime).TotalSeconds);
            _cache.Set(cacheKey, value, expireTimeSpan);
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public void RemoveCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
        public void RemoveAllCache()
        { 
        }
        //    /// <summary>
        //    /// 移除全部缓存
        //    /// </summary>
        //    public void RemoveCache()
        //    {
        //        _cache.RemoveAllCache();
        //    }
    }
}
