using System.Collections.Generic;
using Assets.Code.ViewListeners;

namespace Assets.Code.Services
{
  public class UnityCollidingViewRegister : IRegisterService<IViewController>
  {
    private readonly Dictionary<int, IViewController> _controllerByInstanceId = new Dictionary<int, IViewController>();

    public IViewController Register(int instanceId, IViewController viewController)
    {
      _controllerByInstanceId[instanceId] = viewController;
      return viewController;
    }

    public void Unregister(int instanceId, IViewController @object)
    {
      if (_controllerByInstanceId.ContainsKey(instanceId))
        _controllerByInstanceId.Remove(instanceId);
    }

    public IViewController Take(int key) => 
      _controllerByInstanceId.TryGetValue(key, out IViewController behaviour) 
        ? behaviour 
        : null;
  }
}