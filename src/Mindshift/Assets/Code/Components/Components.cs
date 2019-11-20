using Assets.Code.Services;
using Assets.Code.ViewListeners;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.UI;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Assets.Code.Components
{
  // Services
  [Unique] public class Logger : IComponent, IService { public ILogService Value; }
  [Unique] public class ViewCreator : IComponent, IService { public IViewService Value; }
  [Unique] public class Time : IComponent, IService { public ITimeService Value; }
  [Unique] public class Physics : IComponent, IService { public IPhysicsService Value; }
  [Unique] public class CoroutineDirector : IComponent, IService { public ICoroutineDirectorService Value; }
  [Unique] public class CollidingViewRegister : IComponent, IService { public IRegisterService<IViewController> Value; }
  [Unique] public class Identifiers : IComponent, IService { public IIdentifierService Value; }
  [Unique, Input] public class Input : IComponent, IService { public IInputService Value; }
  
  [Unique, Input] public class LeftMouse : IComponent { }
  [Unique, Input] public class RightMouse : IComponent { }
  [Unique, Input] public class Keyboard : IComponent { }
  
  [Input] public class MouseDown : IComponent { }
  [Input] public class MouseWorldPosition : IComponent { public Vector2 Value; }
  [Input] public class MouseScreenPosition : IComponent { public Vector2 Value; }
  [Input] public class MouseUp : IComponent { }
  [Input] public class Mouse : IComponent { }
  [Input] public class Jump : IComponent { }
  [Input] public class Horizontal : IComponent { public float Value; }

  public class ViewComponent : IComponent { public GameObject Value; }
  public class ViewControllerComponent : IComponent { public IViewController Value; }

  public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
  public class CollisionId : IComponent { [EntityIndex] public int Value; }

  // Lifecycle
  public class OnApplicationQuit : IComponent { }

  // Logic
  public class ViewToLoad : IComponent { public string Value; }

  public class Rigidbody : IComponent { public Rigidbody2D Value; }

  public class Hero : IComponent{ }
  public class CurrentHp : IComponent { public float Value; }
  public class MaxHp : IComponent{ public float Value; }
  public class Damage : IComponent{ public float Value; }
  
  public class Duration : IComponent { public float Value; }

  public class DurationLeft : IComponent { public float Value; }
  public class DurationUp : IComponent { }
  public class ViewPath : IComponent { public string Value; }
  
  public class SelfDestructTimer : IComponent { public float Value; }
  
  public class Burning : IComponent {}
  public class Ignitable : IComponent {}
  public class SpriteRendererComponent : IComponent { public SpriteRenderer Value; }
  public class PolygonCollider2DComponent : IComponent { public PolygonCollider2D Value; }
  public class ImageComponent : IComponent { public Image Value; }
  public class HpBar : IComponent {}
  
  public class Hittable : IComponent {}
  public class Collided : IComponent { }
  
  // Observed
  [Event(Self)] public class Attacking : IComponent{ }
  [Event(Self)] public class DamageTaken : IComponent{ }
  [Event(Self)] public class Died : IComponent{ }
  [Event(Self)] public class Moving : IComponent{ }
  [Event(Self)] public class Jumping : IComponent{ }
  [Event(Self)] public class Grounded : IComponent { }
  [Event(Self)] public class StoppedMoving : IComponent{ }

  
  [Event(Self)] public class Layer : IComponent { public CollisionLayer Value; }
  [Event(Self)] public class Rotation : IComponent { public float Value; }
  [Event(Self)] public class Direction : IComponent { public float Value; }
  [Event(Self)] public class Position : IComponent { public Vector3 Value; }
  [Event(Self)] public class LastUpdatedPosition : IComponent { public Vector3 Value; }
  [Event(Self)] public class Destructed : IComponent { }
}