using Assets.Code.Extensions;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
  public class TriggerOnEnter : EntityBehaviour
  {
    public LayerMask TriggeringLayers;

    private void OnTriggerEnter2D(Collider2D collision) => TriggerBy(collision);

    private void OnTriggerStay2D(Collider2D other) => TriggerBy(other);

    private void TriggerBy(Collider2D collision)
    {
      if (Entity.isCollided)
        return;

      if (collision.Matches(TriggeringLayers))
      {
        GameEntity entered = Game
          .CollidingViewRegister
          .Take(collision.GetInstanceID())
          .Entity;

        Entity.MarkCollided(by: entered.Id);
        entered.MarkCollided(by: Entity.Id);
      }
    }
  }

  public static class CleanCodeExtensions
  {
    public static void MarkCollided(this GameEntity entered, int by)
    {
      entered.isCollided = true;
      entered.ReplaceCollisionId(by);
    }
  }
}