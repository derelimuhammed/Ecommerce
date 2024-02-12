using Core.Ultilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
   public interface IMemoryCacheManager
    {
        /// <summary>
        /// Belirtilen anahtarla önbellekten bir nesne alır.
        /// </summary>
        /// <typeparam name="T">Alınacak nesnenin türü.</typeparam>
        /// <param name="key">Önbellek anahtarı.</param>
        /// <returns>Önbellekten alınan nesne.</returns>
        T Get<T>(string key);
        /// <summary>
        /// Belirtilen anahtarla önbellekten bir nesne alır.
        /// </summary>
        /// <param name="key">Önbellek anahtarı.</param>
        /// <returns>Önbellekten alınan nesne.</returns>
        object Get(string key);
        /// <summary>
        /// Belirtilen anahtar ve süre boyunca bir nesneyi önbelleğe ekler.
        /// </summary>
        /// <param name="key">Önbellek anahtarı.</param>
        /// <param name="data">Önbelleğe eklenecek nesne.</param>
        /// <param name="duration">Nesnenin önbellekte kalacağı süre (dakika cinsinden).</param>
        void Add(string key, object data, int duration);
        /// <summary>
        /// Belirtilen anahtarla bir nesneyi önbelleğe ekler.
        /// </summary>
        /// <param name="key">Önbellek anahtarı.</param>
        /// <param name="data">Önbelleğe eklenecek nesne.</param>
        void Add(string key, object data);
        /// <summary>
        /// Belirtilen anahtarın önbellekte olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="key">Önbellek anahtarı.</param>
        /// <returns>True, anahtarın önbellekte bulunduğunu gösterir; aksi halde false.</returns>
        bool IsAdd(string key);
        /// <summary>
        /// Belirtilen anahtara sahip öğeyi önbellekten kaldırır.
        /// </summary>
        /// <param name="key">Önbellek anahtarı.</param>
        void Remove(string key);
        /// <summary>
        /// Belirtilen desene uyan önbellek girişlerini kaldırır.
        /// </summary>
        /// <param name="pattern">Kaldırılacak önbellek girişlerinin deseni.</param>
        /// <exception cref="InvalidOperationException">Önbellek örneği başlatılmadığında fırlatılır.</exception>
        void RemoveByPattern(string pattern);
    }
}
