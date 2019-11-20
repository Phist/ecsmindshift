using Assets.Code.Behaviours;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class AttackListener : MonoBehaviour, IAttackingListener, IEventListener
  {
    public HeroAnimator Animator;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddAttackingListener(this);
    }

    public void UnregisterListeners(IEntity with) =>
      _entity.RemoveAttackingListener();

    public void OnAttacking(GameEntity entity)
    {
      if (entity.isAttacking)
        Animator.PlayAttack();

      entity.isAttacking = false;
    }
  }
}