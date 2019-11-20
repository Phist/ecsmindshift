using Assets.Code.ViewListeners;

namespace Assets.Code.Services
{
  public class Services
  {
    public ILogService Logger;
    public IIdentifierService Identifiers;
    public IViewService ViewService;
    public ITimeService Time;
    public IInputService InputService;
    public IPhysicsService Physics;
    public ICoroutineDirectorService CoroutineDirector;
    public IRegisterService<IViewController> CollidingViewRegister;
  }
}