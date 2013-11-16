using System;
using System.Collections.Generic;
using System.Linq;

namespace Kenstentions.Collection
{
  public static class CollectionExtensions
  {
      #region Distinct

      public static IEnumerable<TValue> Distinct<TValue, TKey>(
          this IEnumerable<TValue> original,
          Func<TValue, TKey> keyFunction)
      {
          var keys = new List<TKey>();
          foreach (TValue value in original)
          {
              TKey key = keyFunction(value);
              if (!keys.Any(k => k.Equals(key)))
              {
                  keys.Add(key);
                  yield return value;
              }
          }
      }

      #endregion

      #region ListWith

      public static List<T> ListWith<T>(this T first, params T[] rest)
      {
          var list = new List<T> {first};
          list.AddRange(rest);
          return list;
      } 

      #endregion
  }
}
