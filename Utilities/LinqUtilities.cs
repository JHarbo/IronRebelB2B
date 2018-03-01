using System;
using System.Collections.Generic;

namespace IronRebelB2B.Utilities
{
    public static class LinqUtilities
    {
        public static IEnumerable<T> CatchExceptions<T>(this IEnumerable<T> src, System.Action<Exception> action = null)
        {
            using (var enumerator = src.GetEnumerator())
            {
                bool next = true;

                while (next)
                {
                    try
                    {
                        next = enumerator.MoveNext();
                    }
                    catch (Exception ex)
                    {
                        if (action != null)
                        {
                            action(ex);
                        }
                        continue;
                    }

                    if (next)
                    {
                        yield return enumerator.Current;
                    }
                }
            }
        }
    }
}
