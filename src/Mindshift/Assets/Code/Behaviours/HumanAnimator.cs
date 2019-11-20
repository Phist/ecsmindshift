using System;
using Assets.Code.ViewListeners;
using UnityEngine;

namespace Assets.Code.Behaviours
{
  public class HumanAnimator : MonoBehaviour
  {
    private readonly int _walkingHash = Animator.StringToHash("walk");
    private readonly int _idleHash = Animator.StringToHash("isIdling");
    private readonly int _takenHash = Animator.StringToHash("isTaken");
    private readonly int _groundedHash = Animator.StringToHash("isGrounded");

    public Animator Animator;

    private void Start()
    {
      GetComponent<UnityViewController>().Entity.AddLayer(CollisionLayer.Humans);
    }

    public void PlayWalk()
    {
      Reset();
      Animator.SetBool(_walkingHash, true);
    }

    public void PlayIdle()
    {
      Reset();
      Animator.SetBool(_idleHash, true);
    }

    public void PlayTaken()
    {
      Reset();
      Animator.SetBool(_takenHash, true);
    }

    public void PlayGrounded()
    {
      Reset();
      Animator.SetBool(_groundedHash, true);
    }

    public void Reset()
    {
      Animator.SetBool(_walkingHash, false);
      Animator.SetBool(_idleHash, false);
      Animator.SetBool(_takenHash, false);
    }
  }
}
