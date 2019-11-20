using Assets.Code.Behaviours;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class MovingListener : MonoBehaviour, IMovingListener, IStoppedMovingListener, IEventListener
  {
    public HeroAnimator Animator;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddMovingListener(this);
      _entity.AddStoppedMovingListener(this);
    }

    public void UnregisterListeners(IEntity with)
    {
      _entity.RemoveMovingListener();
      _entity.RemoveStoppedMovingListener();
    }

    public void OnMoving(GameEntity entity) =>
      Animator.PlayMove();

    public void OnStoppedMoving(GameEntity entity)
    {
      Animator.PlayIdle();
      entity.isStoppedMoving = false;
    }
  }
}