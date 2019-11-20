using System;
using Assets.Code.Extensions;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class DestructedListener : MonoBehaviour, IEventListener, IDestructedListener
  {
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddDestructedListener(this);

      OnDestructed(_entity);
    }

    public void UnregisterListeners(IEntity with) =>
      _entity.RemoveDestructedListener();

    public void OnDestructed(GameEntity entity) =>
      this.Do(Cleanup(entity), when: entity.isDestructed);

    private Action<DestructedListener> Cleanup(GameEntity entity) =>
      listener =>
      {
        IViewController controller = gameObject.GetComponent<IViewController>();
        controller.Destroy();
      };
  }
}