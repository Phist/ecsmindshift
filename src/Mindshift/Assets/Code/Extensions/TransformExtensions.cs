using UnityEngine;

namespace Assets.Code.Extensions
{
  public static class TransformExtensions
  {
    public static Transform WorldX(this Transform transform, float x)
    {
      transform.position = transform.position.SetX(x);
      return transform;
    }

    public static Transform AddWorldX(this Transform transform, float x)
    {
      transform.position = transform.position.AddX(x);
      return transform;
    }

    public static Transform LocalX(this Transform transform, float x)
    {
      transform.localPosition = transform.localPosition.SetX(x);
      return transform;
    }

    public static Transform LocalScaleX(this Transform transform, float x)
    {
      transform.localScale = transform.localScale.SetX(x);
      return transform;
    }

    public static Transform AddLocalX(this Transform transform, float x)
    {
      transform.localPosition = transform.localPosition.AddX(x);
      return transform;
    }

    public static Transform WorldY(this Transform transform, float y)
    {
      transform.position = transform.position.SetY(y);
      return transform;
    }

    public static Transform AddWorldY(this Transform transform, float y)
    {
      transform.position = transform.position.AddY(y);
      return transform;
    }

    public static Transform LocalY(this Transform transform, float y)
    {
      transform.localPosition = transform.localPosition.SetY(y);
      return transform;
    }

    public static Transform AddLocalY(this Transform transform, float y)
    {
      transform.localPosition = transform.localPosition.AddX(y);
      return transform;
    }
  }
}
