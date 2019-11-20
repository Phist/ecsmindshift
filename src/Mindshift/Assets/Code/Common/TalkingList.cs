using System;
using System.Collections.Generic;

namespace Assets.Code.Common
{
  public class TalkingList<TValue> : List<TValue>
  {
    public new TValue this[int index]
    {
      get
      {
        if (index < 0 || index > Count)
          throw new ArgumentOutOfRangeException($"{index}");
        else
          return base[index];
      }
    }
  }
}