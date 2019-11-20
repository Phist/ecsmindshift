using Entitas;

namespace Assets.Code.Systems.Gameplay.HumanSpawn
{
  public class CleanupDestructed : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _destructed;

    public CleanupDestructed(GameContext game) => 
      _destructed = game.GetGroup(GameMatcher.Destructed);

    public void Cleanup()
    {
      foreach (GameEntity destructed in _destructed.GetEntities())
        destructed.Destroy();
    }
  }
}