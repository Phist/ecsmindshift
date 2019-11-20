using Entitas;

namespace Assets.Code.Systems.Gameplay
{
  public class DisplayHpSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _withHp;
    private readonly IGroup<GameEntity> _hpBars;

    public DisplayHpSystem(GameContext game)
    {
      _withHp = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.CurrentHp, GameMatcher.MaxHp));
      
      _hpBars = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.HpBar, GameMatcher.Image));
    }

    public void Execute()
    {
      foreach (GameEntity withHp in _withHp.GetEntities())
      foreach (GameEntity bar in _hpBars)
        bar.Image.fillAmount = withHp.CurrentHp / withHp.MaxHp;
    }
  }
}