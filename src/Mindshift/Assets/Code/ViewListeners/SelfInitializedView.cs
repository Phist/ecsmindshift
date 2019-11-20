using Assets.Code.Behaviours;
using Assets.Code.Entity;
using Assets.Code.Infrastructure;
using Assets.Code.Services;

namespace Assets.Code.ViewListeners
{
  public class SelfInitializedView : EntityBehaviour
  {
    private GameEntity _entity;

    protected override void OnAwake()
    {
      base.OnAwake();
      _entity = CreateEntity.Empty();

      ViewController.InitializeView(Contexts.sharedInstance.game, _entity);
      
      gameObject.RegisterListeners(_entity);
    }
  }
}
