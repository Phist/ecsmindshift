using Assets.Code.Behaviours;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class DamageTakenListener : MonoBehaviour, IDamageTakenListener, IEventListener
  {
    public HeroAnimator Animator;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddDamageTakenListener(this);
    }

    public void UnregisterListeners(IEntity with) =>
      _entity.RemoveDamageTakenListener();

    public void OnDamageTaken(GameEntity entity)
    {
      Animator.PlayDamageTaken();
      entity.isDamageTaken = false;
    }
  }
}