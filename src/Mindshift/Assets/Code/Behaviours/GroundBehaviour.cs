using Assets.Code.Extensions;
using Assets.Code.Infrastructure;
using Assets.Code.ViewListeners;
using UnityEngine;

namespace Assets.Code.Behaviours
{
  public class GroundBehaviour : EntityBehaviour
  {
    private static UnityViewController _controller;

    private void OnTriggerEnter2D(Collider2D collided) => MarkGrounded(collided);
    private void OnTriggerExit2D(Collider2D collided) => UnmarkGrounded(collided);

    private void OnCollisionEnter2D(Collision2D other) => MarkGrounded(other.collider);

    private void OnTriggerStay2D(Collider2D collided) => MarkGrounded(collided);

    private void MarkGrounded(Collider2D collision)
    {
      Game
        .CollidingViewRegister
        .Take(collision.GetInstanceID())
        .With(x => x.Entity.isGrounded = true);
    }

    private void UnmarkGrounded(Collider2D collision)
    {
      Game
        .CollidingViewRegister
        .Take(collision.GetInstanceID())?
        .With(x => x.Entity?.With(e => e.isGrounded = false));
    }
  }
}