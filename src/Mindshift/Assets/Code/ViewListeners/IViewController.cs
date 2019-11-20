using Entitas;

namespace Assets.Code.ViewListeners
{
  public interface IViewController
  {
    IViewController InitializeView(GameContext @in, IEntity @with);
    void Destroy();
    GameEntity Entity { get; }
  }
}
