using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class RotationListener : MonoBehaviour, IEventListener, IRotationListener
  {
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddRotationListener(this);

      UpdateCurrentDirection();
    }

    public void UnregisterListeners(IEntity with) => 
      _entity.RemoveRotationListener();

    public void OnRotation(GameEntity entity, float angle) => 
      transform.rotation = TransformRotation(@by: angle);

    private void UpdateCurrentDirection()
    {
      if (_entity.hasRotation)
        OnRotation(_entity, _entity.Rotation);
    }

    private static Quaternion TransformRotation(float @by) => 
      Quaternion.AngleAxis(@by - 90, Vector3.forward);
  }
}