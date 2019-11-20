using Assets.Code.Extensions;
using Assets.Code.Infrastructure;
using UnityEngine;

namespace Assets.Code.Behaviours
{
  public class HittableBehaviour : EntityBehaviour
  {
    public SpriteFX DestroyFxPref;
    private bool _quitting;

    protected override void OnStart()
    {
      base.OnStart();
      Entity
        .With(x => x.isHittable = true);

      Application.quitting += () => _quitting = true;
    }

    protected override void OnDestroying()
    {
      if (!_quitting)
      {
        Instantiate(DestroyFxPref)
          .Play(transform.position, isWorldPos: true);
      }

      base.OnDestroying();
    }
  }
}