using Assets.Code.ViewListeners;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
  public class EntityBehaviour : MonoBehaviour
  {
    public UnityViewController ViewController;

    public bool ExpectsViewInParent;    
    
    public UnityViewController Controller => ViewController;

    public GameContext Game => Contexts.sharedInstance.game;
    public GameEntity Entity => Controller.Entity;
    
    private void Awake()
    {
      if (!ExpectsViewInParent && ViewController == null)
        ViewController = GetComponent<UnityViewController>();

      OnAwake();
    }

    private void Start() => OnStart();

    private void OnDestroy()
    {
      if (ViewController != null && ViewController.Entity?.isEnabled == true)
        ViewController.Entity.isDestructed = true;

      OnDestroying();
    }

    private void OnEnable() => OnEnabled();

    private void OnDisable() => OnDisabled();

    protected virtual void OnAwake()
    {
    }

    protected virtual void OnStart()
    {
    }

    protected virtual void OnEnabled()
    {
    }

    protected virtual void OnDisabled()
    {
    }

    protected virtual void OnDestroying()
    {
    }
  }
}