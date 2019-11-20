using Entitas;

namespace Code.Systems.Gameplay.Hero
{
  public class HeroAirborneSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _heroes;

    public HeroAirborneSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Hero)
        .NoneOf(GameMatcher.Grounded, GameMatcher.Jumping));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes.GetEntities())
        hero.isJumping = true;
    }
  }
}