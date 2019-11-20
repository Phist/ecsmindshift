using Assets.Code.Common;
using Assets.Code.ViewListeners;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
  public class DestroyCollider : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other) => SafeDestroy(other.GetInstanceID(), other.gameObject);
    private void OnTriggerEnter2D(Collider2D collision) => SafeDestroy(collision.GetInstanceID(), collision.gameObject);

    private static void SafeDestroy(int colliderInstanceID, GameObject gameObject)
    {
      IViewController viewController = StaticCleaners.Game()
        .CollidingViewRegister
        .Take(colliderInstanceID);

      if (viewController != null)
      {
        if (viewController.Entity.isEnabled) 
          viewController.Entity.isDestructed = true;
      }
      else
        Destroy(gameObject);
    }
  }
}