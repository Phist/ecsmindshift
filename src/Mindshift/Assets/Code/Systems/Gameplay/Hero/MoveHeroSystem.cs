using Assets.Code.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Systems.Gameplay.Hero
{
  public class MoveHeroSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private const float Speed = 1.5f;
    
    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<InputEntity> _inputs;

    public MoveHeroSystem(GameContext game, InputContext input)
    {
      _game = game;
      
      _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero));
      _inputs = input.GetGroup(InputMatcher.AllOf(InputMatcher.Horizontal));
    }

    public void Execute()
    {
      foreach (InputEntity input in _inputs)
      foreach (GameEntity hero in _heroes)
      {
        if (Mathf.Abs(input.Horizontal) > 0)
          Move(hero, @in: Direction(input.Horizontal));
        else
        {
          hero.isMoving = false;
          hero.isStoppedMoving = true;
        }
      }
    }

    private static float Direction(float xDistance) => Mathf.Sign(xDistance);

    private void Move(GameEntity hero, float @in)
    {
      hero.isMoving = true;
      hero.isStoppedMoving = false;
//      hero.ReplacePosition(hero.Position.AddX(direction * Speed * _game.Time.DeltaTime));
      hero.Rigidbody.position = hero.Rigidbody.position.AddX(@in * Speed * _game.Time.DeltaTime);
      
      UpdateDirection(hero, @in);
    }

    private static void UpdateDirection(GameEntity boss, float direction)
    {
      // ReSharper disable once CompareOfFloatsByEqualityOperator
      if (boss.hasDirection && boss.Direction == direction)
        return;

      boss.ReplaceDirection(direction);
    }
  }
}