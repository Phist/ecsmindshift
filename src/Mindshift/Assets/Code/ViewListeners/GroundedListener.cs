using Assets.Code.Behaviours;
using Assets.Code.Extensions;
using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class GroundedListener : MonoBehaviour, IEventListener, IGroundedListener
  {
    private GameEntity _entity;
    private HumanAnimator _human;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddGroundedListener(this);

      _human = GetComponent<HumanAnimator>();

      OnGrounded(_entity);
    }

    public void UnregisterListeners(IEntity with) =>
      _entity.RemoveGroundedListener();

    public void OnGrounded(GameEntity entity) =>
      _human.Do(h => h.PlayGrounded(), when: entity.isGrounded);

  }
}