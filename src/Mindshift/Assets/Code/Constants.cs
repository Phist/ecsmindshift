using UnityEngine;

namespace Assets.Code
{
  public static class Constants
  {
    public const string GameSavePath = "save.zydrate";

    public const string ViewRootName = "ViewRoot";
    public const string UIRootName = "UIRoot";

    public const float PixelPerUnit = 100;
    public const float PressHumanTime = 0.5f;
  }

  public enum CollisionLayer
  {
    GroundTrigger = 9,
    Humans = 10,
    Taken = 11,
    Dropped = 12,
    Ground = 14,
    DestroyCollider = 15,
    SacrificeKillers = 16,
    TriggerOnHuman = 17,
    ClickRaycastTarget = 18,
    Boss = 19,
    Clickers = 20,
  }

  public static partial class CleanCodeExtensions
  {
    public static int AsMask(this CollisionLayer layer) => 1 << LayerMask.NameToLayer(layer.ToString());
  }

}