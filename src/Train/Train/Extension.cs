using System;

namespace Train
{
    static class Extension
    {
        public static bool Contains<T>(this T[] array, Func<T, bool> predicate)
        {
            foreach (var item in array)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
