using LazyConditions.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LazyConditions
{
    public static class Conditions
    {
        public static bool AllTrue(params bool[] conditions) => conditions.All(_ => _);
        public static bool AllTrue(params Lazy<bool>[] conditions) => conditions.All(_ => _.Value);
        public static Task<bool> AllTrueAsync(params Lazy<Task<bool>>[] conditions) => conditions.AllAsync(_ => _.Value);
        public static bool AnyTrue(params bool[] conditions) => conditions.Any(_ => _);
        public static bool AnyTrue(params Lazy<bool>[] conditions) => conditions.Any(_ => _.Value);
        public static Task<bool> AnyTrueAsync(params Lazy<Task<bool>>[] conditions) => conditions.AnyAsync(_ => _.Value);

        public static bool AllFalse(params bool[] conditions) => conditions.All(_ => !_);
        public static bool AllFalse(params Lazy<bool>[] conditions) => conditions.All(_ => !_.Value);
        public static Task<bool> AllFalseAsync(params Lazy<Task<bool>>[] conditions) => conditions.AllAsync(_ => _.Value, true);
        public static bool AnyFalse(params bool[] conditions) => conditions.Any(_ => !_);
        public static bool AnyFalse(params Lazy<bool>[] conditions) => conditions.Any(_ => !_.Value);
        public static Task<bool> AnyFalseAsync(params Lazy<Task<bool>>[] conditions) => conditions.AnyAsync(_ => _.Value, true);
    }
}
