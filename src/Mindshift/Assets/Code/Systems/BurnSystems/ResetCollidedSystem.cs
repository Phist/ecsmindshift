using Entitas;

namespace Assets.Code.Systems.Gameplay
{
  public class ResetCollidedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _triggered;

    public ResetCollidedSystem(GameContext game)
    {
      _triggered = game.GetGroup(GameMatcher.AllOf(GameMatcher.Collided));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _triggered.GetEntities()) 
        entity.isCollided = false;
    }
  }
}