using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultilities.Extensions
{
    public static class LinqExtensionMethod
    {
        /// <summary>
        /// IQueryable koleksiyonunu verilen arama terimleri ve test fonksiyonu kullanarak filtreleyen genişletme yöntemi.
        /// </summary>
        /// <typeparam name="T">Filtrelenecek öğelerin türü.</typeparam>
        /// <typeparam name="TKey">Arama terimlerinin türü.</typeparam>
        /// <param name="queryCol">Filtreleme işlemi uygulanacak IQueryable koleksiyonu.</param>
        /// <param name="searchTerms">Filtreleme için kullanılacak arama terimlerini içeren IEnumerable koleksiyonu.</param>
        /// <param name="testFne">Filtreleme koşulunu belirleyen test fonksiyonu.</param>
        /// <returns>Filtrelenmiş IQueryable koleksiyonu.</returns>
        public static IQueryable<T> WhereAll<T, TKey>(this IQueryable<T> queryCol, IEnumerable<TKey> searchName, Expression<Func<T, TKey, bool>> func)
        {
            // Yeni bir PredicateBuilder oluşturulur.
            var pred = PredicateBuilder.New<T>();

            // Her arama terimi için testFne fonksiyonu çağrılarak birleştirilen bir koşul oluşturulur.
            foreach (var st in searchName)
                pred = pred.And(x => func.Invoke(x, st));

            // Oluşturulan koşul, IQueryable koleksiyonunda genişletilerek filtreleme gerçekleştirilir ve sonuç döndürülür.
            return queryCol.Where((Expression<Func<T, bool>>)pred.Expand());
        }

    }
}
