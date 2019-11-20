using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Extensions
{
  public static class ColorExtensions
  {
    public static Color Alpha(this Color color, float a)
    {
      color.a = a;
      return color;
    }

    public static Color R(this Color color, float r)
    {
      color.r = r;
      return color;
    }

    public static Color G(this Color color, float g)
    {
      color.g = g;
      return color;
    }

    public static Color B(this Color color, float b)
    {
      color.b = b;
      return color;
    }

    public static void Alpha(this SpriteRenderer spriteRenderer, float a) =>
      spriteRenderer.color = spriteRenderer.color.Alpha(a);

    public static void Alpha(this Image image, float a) => image.color = image.color.Alpha(a);

    public static void Alpha(this Text text, float a) => text.color = text.color.Alpha(a);

    public static Image AddA(this Image image, float a)
    {
      var color = image.color;
      color.a = image.color.a + a;

      image.color = color;
      return image;
    }

    public static Image R(this Image image, float r)
    {
      image.color = image.color.R(r);
      return image;
    }

    public static Image G(this Image image, float g)
    {
      image.color = image.color.G(g);
      return image;
    }

    public static Image B(this Image image, float b)
    {
      image.color = image.color.B(b);
      return image;
    }

    public static Image AddR(this Image image, float r)
    {
      var color = image.color;
      color.r = image.color.r + r;

      image.color = color;
      return image;
    }

    public static Image AddG(this Image image, float g)
    {
      var color = image.color;
      color.g = image.color.g + g;

      image.color = color;
      return image;
    }

    public static Image AddB(this Image image, float b)
    {
      var color = image.color;
      color.b = image.color.b + b;

      image.color = color;
      return image;
    }
  }
}
