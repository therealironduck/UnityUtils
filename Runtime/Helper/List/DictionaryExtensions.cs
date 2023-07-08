using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheRealIronDuck.Runtime.Helper.List
{
    public static class DictionaryExtensions
    {
        #region PUBLIC METHODS
        
        public static KeyValuePair<TKey, TValue> RandomItem<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary.Count == 0)
            {
                return default;
            }

            var randomIndex = Random.Range(0, dictionary.Count);
            return dictionary.ToList()[randomIndex];
        }
        
        #endregion
    }
}