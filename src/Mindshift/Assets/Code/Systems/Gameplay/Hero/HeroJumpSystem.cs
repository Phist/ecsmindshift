using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Systems.Gameplay.Hero
{
  public class HeroJumpSystem : ReactiveSystem<InputEntity>
  {
    private readonly IGroup<GameEntity> _heroes;
    private const float JumpForce = 6;

    public HeroJumpSystem(GameContext game, InputContext input) : base(input)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Hero, GameMatcher.Rigidbody, GameMatcher.Grounded)
        .NoneOf(GameMatcher.Jumping));
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) =>
      context.CreateCollector(InputMatcher.Jump.Added());

    protected override bool Filter(InputEntity input) => input.isJump;

    protected override void Execute(List<InputEntity> jumpInputs)
    {
      foreach (InputEntity _ in jumpInputs)
      foreach (GameEntity hero in _heroes.GetEntities())
      {
        hero.isJumping = true;
        hero.Rigidbody.AddForce(new Vector2(0, 1) * JumpForce, ForceMode2D.Impulse);
      }
    }
  }
}