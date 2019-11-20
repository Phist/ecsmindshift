using Entitas;

namespace Assets.Code.Systems.Gameplay
{
  public class ExtinguishOnDurationUp : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _burning;

    public ExtinguishOnDurationUp(GameContext game)
    {
      _burning = game.GetGroup(GameMatcher.AllOf(GameMatcher.Burning, GameMatcher.DurationUp));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _burning.GetEntities())
      {
        entity.isBurning = false;
        entity.isDurationUp = false;
        entity.RemoveDuration();
      }
    }
  }
}