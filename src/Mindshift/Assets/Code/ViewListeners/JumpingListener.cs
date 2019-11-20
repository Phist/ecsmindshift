using Assets.Code.Behaviours;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class JumpingListener : MonoBehaviour, IJumpingListener, IGroundedListener, IEventListener
  {
    public HeroAnimator Animator;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddJumpingListener(this);
      _entity.AddGroundedListener(this);
    }

    public void UnregisterListeners(IEntity with)
    {
      _entity.RemoveMovingListener();
      _entity.RemoveStoppedMovingListener();
    }

    public void OnJumping(GameEntity entity) => Animator.PlayJump();
    public void OnGrounded(GameEntity entity) => Animator.PlayGrounded();
  }
}