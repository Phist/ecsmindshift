using System.Collections.Generic;
using Assets.Code.ViewListeners;
using UnityEngine;
using static Assets.Code.Common.StaticCleaners;

namespace Assets.Code.Services
{
  public class UnityPhysicsService : IPhysicsService
  {
    private static readonly Collider2D[] CircleCastHits = new Collider2D[30];
    private static readonly RaycastHit2D[] Hits = new RaycastHit2D[20];

    public IEnumerable<GameEntity> RaycastThroughScreenPoint(Vector2 position, int layerMask)
    {
      Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
      int hitCount = Raycast(worldPos, Hits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit2D hit = Hits[i];
        if (hit.collider == null)
          continue;

        IViewController controller = TakeViewController(hit.collider.GetInstanceID());
        if (controller == null)
          continue;

        yield return controller.Entity;
      }
    }

    public IEnumerable<GameEntity> RaycastCircle(Vector3 position, float radius, int layerMask)
    {
      int hitCount = Overlap(position, radius, CircleCastHits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        IViewController controller = TakeViewController(CircleCastHits[i].GetInstanceID());
        if (controller == null)
          continue;

        yield return controller.Entity;
      }
    }

    private static IViewController TakeViewController(int instanceId)
    {
      IViewController viewController =
        Game()
          .CollidingViewRegister
          .Take(instanceId);
      return viewController;
    }

    private static int Raycast(Vector2 worldPos, RaycastHit2D[] hits, int layerMask) =>
      Physics2D.LinecastNonAlloc(worldPos, worldPos, hits, layerMask);

    public static int Overlap(Vector2 worldPos, float radius, Collider2D[] hits, int layerMask) =>
      Physics2D.OverlapCircleNonAlloc(worldPos, radius, hits, layerMask);
  }
}