using Assets.Code.ViewListeners;
using Entitas;

namespace Assets.Code.Systems.Gameplay
{
  public class LoadViewSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _viewsToLoad;

    public LoadViewSystem(GameContext game)
    {
      _game = game;
      _viewsToLoad = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.ViewToLoad)
        .NoneOf(GameMatcher.ViewController));
    }

    public void Execute()
    {
      foreach (GameEntity view in _viewsToLoad.GetEntities()) 
        _game.ViewCreator.LoadView<UnityViewController>(_game, view, view.ViewToLoad);
    }
  }
}