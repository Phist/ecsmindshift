using Entitas;

namespace Assets.Code.ViewListeners
{
  public interface IEventListener
  {
    void RegisterListeners(IEntity entity);
    void UnregisterListeners(IEntity with);
  }
}