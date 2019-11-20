using Entitas;

namespace Assets.Code.Systems.Gameplay
{
  public class DurationSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _withDuration;

    public DurationSystem(GameContext game)
    {
      _game = game;
      _withDuration = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.DurationLeft)
        .NoneOf(GameMatcher.DurationUp));
    }

    public void Execute()
    {
      foreach (GameEntity cooldownable in _withDuration.GetEntities())
      {
        cooldownable.ReplaceDurationLeft(cooldownable.DurationLeft - _game.Time.DeltaTime);

        if (cooldownable.DurationLeft <= 0)
        {
          cooldownable.isDurationUp = true;
          cooldownable.RemoveDurationLeft();
        }
      }
    }
  }
}