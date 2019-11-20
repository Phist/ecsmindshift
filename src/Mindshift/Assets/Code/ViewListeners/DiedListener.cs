using Assets.Code.Behaviours;
using Assets.Code.Common;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class DiedListener : MonoBehaviour, IDiedListener, IEventListener
  {
    public HeroAnimator Animator;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddDiedListener(this);
    }

    public void UnregisterListeners(IEntity with) =>
      _entity.RemoveDiedListener();


    public void OnDied(GameEntity entity)
    {
      Animator.PlayDied();

      Delay.For(4f, () => entity.isDestructed = true);
    }
  }
}