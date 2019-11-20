using System;
using System.Collections.Generic;

namespace Assets.Code.Common
{
  public class TalkingDictionary<TKey, TValue> : Dictionary<TKey, TValue>
  {
    public new TValue this[TKey key]
    {
      get
      {
        if(key == null)
          throw new ArgumentNullException($"{nameof(key)}");
        
        if (ContainsKey(key))
          return base[key];
        else
          throw new KeyNotFoundException($"{nameof(key)} {key} was not found in {this}");
      }
    }
  }
}