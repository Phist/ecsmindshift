using Assets.Code.Entity;
using Entitas;

namespace Assets.Code.Systems.Gameplay
{
  public class IgniteFromBurningOnCollision : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _burning;
    private readonly IGroup<GameEntity> _ignitables;
    private const float Duration = 6; 

    public IgniteFromBurningOnCollision(GameContext game)
    {
      _burning = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Burning, GameMatcher.Collided, GameMatcher.CollisionId));

      _ignitables = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Id, GameMatcher.Ignitable)
        .NoneOf(GameMatcher.Burning));
    }

    public void Execute()
    {
      foreach (GameEntity burning in _burning.GetEntities())
      foreach (GameEntity ignitable in _ignitables.GetEntities())
      {
        if (ignitable.Id == burning.CollisionId)
        {
          ignitable.isBurning = true;
          ignitable.WindUpDuration(Duration);
        }
      }
    }
  }
}