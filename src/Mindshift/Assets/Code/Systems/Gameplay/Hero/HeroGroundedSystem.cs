using Entitas;

namespace Code.Systems.Gameplay.Hero
{
  public class HeroGroundedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _heroes;

    public HeroGroundedSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Grounded, GameMatcher.Jumping));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes.GetEntities()) 
        hero.isJumping = false;
    }
  }
}