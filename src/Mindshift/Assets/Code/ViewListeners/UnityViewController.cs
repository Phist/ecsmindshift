using System.Collections.Generic;
using System.Linq;
using Assets.Code.Entity;
using Assets.Code.Extensions;
using Assets.Code.ViewComponentRegistrators;
using Entitas;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using EntityBehaviour = Assets.Code.Infrastructure.EntityBehaviour;


namespace Assets.Code.ViewListeners
{
  public class UnityViewController : MonoBehaviour, IViewController
  {
    public GameContext Game { get; private set; }
    public GameEntity Entity { get; private set; }

    public IViewController InitializeView(GameContext game, IEntity entity)
    {
      Game = game;
      Entity = (GameEntity) entity;

      Entity.AddViewController(this);

      AddDestructedListener();

      RegisterViewComponents();

      return this;
    }

    public void Destroy()
    {
      UnregisterCollisions();
      gameObject.UnregisterListeners(Entity);
      gameObject.DestroyGameObject();
    }

    private void Start()
    {
      RegisterCollisions();
      Entity.WithNewGeneralId();
    }

    private void RegisterViewComponents()
    {
      foreach (IViewComponentRegistrator registrator in GetComponents<IViewComponentRegistrator>())
        registrator.Register(Entity);

      AddRenderer();

      InflateEntityBehaviours();

      void AddRenderer()
      {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Entity.Do(x => x.AddSpriteRenderer(spriteRenderer), when: spriteRenderer != null);
      }
    }

    private void InflateEntityBehaviours()
    {
      foreach (EntityBehaviour behaviour in FittingBehaviours())
      {
        if (behaviour.Controller == null)
          behaviour.ViewController = this;
      }

      IEnumerable<EntityBehaviour> FittingBehaviours() =>
        GetComponentsInChildren<EntityBehaviour>()
          .Where(x => x.gameObject == gameObject || x.ExpectsViewInParent);
    }

    private void AddDestructedListener()
    {
      var destructedListener = GetComponent<DestructedListener>();
      if (destructedListener == null)
        gameObject.AddComponent<DestructedListener>();
    }

    private void RegisterCollisions()
    {
      foreach (Collider2D collider in GetComponentsInChildren<Collider2D>(includeInactive: true))
        Game.CollidingViewRegister.Register(collider.GetInstanceID(), this);
    }

    private void UnregisterCollisions()
    {
      foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
        Game.CollidingViewRegister.Unregister(collider.GetInstanceID(), this);
    }
  }

  public static partial class CleanCodeExtensions
  {
    public static void UnregisterListeners(this GameObject view, IEntity with)
    {
      foreach (IEventListener listener in view.GetComponents<IEventListener>())
        listener.UnregisterListeners(with);
    }
  }
}