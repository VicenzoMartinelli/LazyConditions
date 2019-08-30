using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LazyConditions.Extensions
{
    public static class AsyncLinqExtensions
    {
        public static async Task<bool> AnyAsync<T>(
            this IEnumerable<T> source, Func<T, Task<bool>> func, bool invert = false)
        {
            foreach (var element in source)
            {
                var result = await func(element);

                if (invert)
                    result = !result;

                if (result)
                    return true;
            }
            return false;
        }

        public static async Task<bool> AllAsync<TSource>(
            this IEnumerable<TSource> source, Func<TSource,
                Task<bool>> predicate,
                bool invert = false)
        {
            foreach (var item in source)
            {
                var result = await predicate(item);

                if (invert)
                    result = !result;

                if (!result)
                    return false;
            }
            return true;
        }
    }
}
