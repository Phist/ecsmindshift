using Assets.Code.Extensions;
using Assets.Code.Infrastructure;

namespace Assets.Code.Behaviours
{
  public class HeroBehaviour : EntityBehaviour
  {
    protected override void OnStart()
    {
      base.OnStart();
      Entity
        .With(x => x.isHero = true)
        .AddMaxHp(100)
        .AddPosition(transform.position)
        .AddCurrentHp(100)
        .AddDamage(10);
    }
  }
}