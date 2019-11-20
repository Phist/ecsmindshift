using Assets.Code.Extensions;
using Entitas;
using UnityEngine;

namespace Assets.Code.Systems.Gameplay
{
  public class DestroyHittableSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _triggeredHittables;

    public DestroyHittableSystem(GameContext game)
    {
      _game = game;
      _triggeredHittables = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Hittable, GameMatcher.Collided));
    }

    public void Execute()
    {
      foreach (GameEntity hittable in _triggeredHittables.GetEntities())
      {
        hittable.isDestructed = true;

        _game
          .GetEntityWithId(hittable.CollisionId)
          .With(x => x.SpriteRenderer.color = new Color32(60, 35, 35, 255))
          .With(x => x.isIgnitable = true);
      }
    }
  }
}