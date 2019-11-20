using Assets.Code.Extensions;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class DirectionListener : MonoBehaviour, IEventListener, IDirectionListener
  {
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddDirectionListener(this);

      UpdateCurrentDirection();
    }

    public void UnregisterListeners(IEntity with) => 
      _entity.RemoveDirectionListener();

    public void OnDirection(GameEntity entity, float direction)
    {
      float currentXScaleValue = Mathf.Abs(transform.localScale.x);
      transform.LocalScaleX(currentXScaleValue * direction);
    }

    private void UpdateCurrentDirection()
    {
      if (_entity.hasDirection)
        OnDirection(_entity, _entity.Direction);
    }
  }
}