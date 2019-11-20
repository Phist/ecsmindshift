using System.Collections.Generic;
using Entitas;

namespace Code.Systems.Gameplay.Hero
{
  public class HeroAttackSystem : ReactiveSystem<InputEntity>
  {
    private readonly IGroup<GameEntity> _heroes;

    public HeroAttackSystem(GameContext game, InputContext input) : base(input)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Hero));
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) =>
      context.CreateCollector(InputMatcher.MouseUp.Added());

    protected override bool Filter(InputEntity input) => input.isLeftMouse;

    protected override void Execute(List<InputEntity> _attackInputs)
    {
      foreach (InputEntity _ in _attackInputs)
      foreach (GameEntity hero in _heroes.GetEntities())
        hero.isAttacking = true;
    }
  }
}