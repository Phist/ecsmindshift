using UnityEngine;

namespace Assets.Code.ViewComponentRegistrators
{
  public class PolygonColliderRegistrator : MonoBehaviour, IViewComponentRegistrator
  {
    public PolygonCollider2D Collider;

    public void Register(GameEntity entity) =>
      entity.AddPolygonCollider2D(Collider ?? (Collider = GetComponentInChildren<PolygonCollider2D>()));
  }
}