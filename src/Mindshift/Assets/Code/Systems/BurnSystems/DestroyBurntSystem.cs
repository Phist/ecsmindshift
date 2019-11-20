using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Assets.Code.Systems.Gameplay
{
  public class DestroyBurntSystem : ReactiveSystem<GameEntity>
  {
    private readonly GameContext _game;

    public DestroyBurntSystem(GameContext game) : base(game)
    {
      _game = game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Burning.Removed());

    protected override bool Filter(GameEntity entity) => !entity.isBurning && !entity.hasCurrentHp && entity.hasSpriteRenderer;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity entity in entities) 
        _game.CoroutineDirector.Start(FadeAndDestroy(entity));
    }

    private IEnumerator FadeAndDestroy(GameEntity entity)
    {
      const int duration = 5;
      Color start = BurnSpriteSystem.BurnColor;
      
      for (float i = 0; i < duration; i++)
      {
        entity.SpriteRenderer.color = Color.Lerp(start, new Color(0,0,0,0), i/5f);
        yield return new WaitForSeconds(0.1f);
      }
      
      entity.isDestructed = true;
    }
  }
}