using System;

namespace Assets.Code.Extensions
{
  public static class FunctionalExtensions
  {
    public static T With<T>(this T self, Action<T> set)
    {
      set.Invoke(self);
      return self;
    }

    public static T With<T>(this T self, Action<T> apply, Func<bool> when)
    {
      if (when())
        apply?.Invoke(self);

      return self;
    }

    public static T With<T>(this T self, Action<T> apply, Func<T, bool> when)
    {
      if (when(self))
        apply?.Invoke(self);

      return self;
    }

    public static T With<T>(this T self, Action<T> apply, bool when)
    {
      if (when)
        apply?.Invoke(self);

      return self;
    }

    public static T Do<T>(this T @self, Action<T> @this, bool @when)
    {
      if (when)
        @this?.Invoke(self);

      return self;
    }
  }
}
