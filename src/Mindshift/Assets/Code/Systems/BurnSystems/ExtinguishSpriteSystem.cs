using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Assets.Code.Systems.Gameplay
{
  public class ExtinguishSpriteSystem : ReactiveSystem<GameEntity>
  {
    public ExtinguishSpriteSystem(GameContext game) : base(game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Burning.Removed());

    protected override bool Filter(GameEntity entity) => !entity.isBurning && entity.hasSpriteRenderer;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity entity in entities)
      {
        entity.SpriteRenderer.color = Color.white;

        foreach (ParticleSystem particleSystem in entity.SpriteRenderer.gameObject.GetComponentsInChildren<ParticleSystem>())
          Object.Destroy(particleSystem.transform.parent.gameObject);
      }
    }
  }
}