using Entitas;

namespace Assets.Code.Systems.Gameplay
{
  public class BurnHpSystem : TimerExecuteSystem
  {
    private readonly IGroup<GameEntity> _burning;

    public BurnHpSystem(GameContext game, float period) : base(period)
    {
      _burning = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.Burning, GameMatcher.CurrentHp));
    }

    protected override void Execute()
    {
      foreach (GameEntity burning in _burning.GetEntities()) 
        burning.ReplaceCurrentHp(burning.CurrentHp - 2);
    }
  }
}