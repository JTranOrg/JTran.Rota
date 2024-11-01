using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rota.Service
{
    public static class AsyncEnumerableExtensions
    {
        public static async Task<IList<T>> ToListAsync<T>(this IAsyncEnumerable<T> enm)
        {
            var result = new List<T>();

            await foreach (var item in enm) 
            {
                result.Add(item);
            }

            return result;
        }
    }
}
