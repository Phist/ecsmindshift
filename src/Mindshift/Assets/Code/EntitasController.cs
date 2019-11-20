using Assets.Code.Entity;
using Assets.Code.Services;
using Assets.Code.Systems;
using UnityEngine;

namespace Assets.Code
{
  public class EntitasController : MonoBehaviour
  {
    private Entitas.Systems _systems;
    private Services.Services _services;

    private void Awake()
    {
      _services = new Services.Services
      {
        Logger = new UnityDebugLogService(),
        ViewService = new UnityViewService(),
        Time = new UnityTimeService(),
        Physics = new UnityPhysicsService(),
        CoroutineDirector = new UnityCoroutineDirectorService(this),
        CollidingViewRegister = new UnityCollidingViewRegister(),
        Identifiers = new GameIdentifierService(),
        InputService = new StandaloneInputService(),
      };

      Contexts contexts = Contexts.sharedInstance;

      _systems = new AllSystems(contexts, _services);
      _systems.Initialize();
    }

    private void Update()
    {
      _systems.Execute();

      _systems.Cleanup();
    }

    private void OnApplicationQuit()
    {
      CreateEntity.Empty().isOnApplicationQuit = true;

      _systems.Execute();

      _systems.Cleanup();
    }
  }
}