using UnityEngine;

namespace Assets.Code.Extensions
{
  public static class VectorExtensions
  {
    public static Vector3 SetX(this Vector3 v, float x)
    {
      var tmp = v;
      tmp.x = x;
      v = tmp;
      return v;
    }

    public static Vector3 SetY(this Vector3 v, float y)
    {
      var tmp = v;
      tmp.y = y;
      v = tmp;
      return v;
    }

    public static Vector3 SetZ(this Vector3 v, float z)
    {
      var tmp = v;
      tmp.z = z;
      v = tmp;
      return v;
    }

    public static Vector2 SetX(this Vector2 v, float x)
    {
      var tmp = v;
      tmp.x = x;
      v = tmp;
      return v;
    }

    public static Vector2 SetY(this Vector2 v, float y)
    {
      var tmp = v;
      tmp.y = y;
      v = tmp;
      return v;
    }

    public static Vector3 AddX(this Vector3 v, float xDelta)
    {
      var tmp = v;
      tmp.x = tmp.x + xDelta;
      v = tmp;
      return v;
    }

    public static Vector3 AddY(this Vector3 v, float yDelta)
    {
      var tmp = v;
      tmp.y = tmp.y + yDelta;
      v = tmp;
      return v;
    }

    public static Vector2 AddX(this Vector2 v, float xDelta)
    {
      var tmp = v;
      tmp.x = tmp.x + xDelta;
      v = tmp;
      return v;
    }

    public static Vector2 AddY(this Vector2 v, float yDelta)
    {
      var tmp = v;
      tmp.y = tmp.y + yDelta;
      v = tmp;
      return v;
    }
  }
}