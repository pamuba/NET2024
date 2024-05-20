using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<T> NewWhere<T>
            (this IEnumerable<T> items, Func<T, bool> predicate)
        { 
            //var list = new List<T>();
            foreach (var item in items)
            {
                if (predicate(item)) {
                    //list.Add(item);
                    yield return item;
                }
            }
            //return list;
        }
    }
}
