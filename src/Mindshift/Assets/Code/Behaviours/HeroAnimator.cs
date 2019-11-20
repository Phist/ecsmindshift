using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Behaviours
{
  public class HeroAnimator : MonoBehaviour
  {
    private readonly int _isMovingHash = Animator.StringToHash("isMoving");
    private readonly int _isJumpingHash = Animator.StringToHash("jumping");
    private readonly int _damageTakenHash = Animator.StringToHash("damageTaken");
    private readonly int _attackHash = Animator.StringToHash("attack");
    private readonly int _diedHash = Animator.StringToHash("died");

    public Color DamageTakenColor;

    public Animator Animator;
    public SpriteRenderer SpriteRenderer;

    public void PlayMove() => Animator.SetBool(_isMovingHash, true);
    public void PlayJump() => Animator.SetBool(_isJumpingHash, true);
    public void PlayGrounded() => Animator.SetBool(_isJumpingHash, false);
    public void PlayIdle() => Animator.SetBool(_isMovingHash, false);

    public void PlayDamageTaken()
    {
      SpriteRenderer.material.color = DamageTakenColor;
      Delay.For(0.1f, andThen: () => SpriteRenderer.material.color = Color.white);
    }

    public void PlayAttack() => Animator.SetTrigger(_attackHash);

    public void PlayDied() => Animator.SetTrigger(_diedHash);

    public void Reset()
    {
      Animator.ResetTrigger(_damageTakenHash);
      Animator.ResetTrigger(_attackHash);
      Animator.ResetTrigger(_diedHash);
    }
  }
}