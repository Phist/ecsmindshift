using Assets.Code.Extensions;
using Assets.Code.Infrastructure;

namespace Assets.Code.Behaviours
{
  public class IgnitableBehaviour : EntityBehaviour
  {
    protected override void OnStart()
    {
      base.OnStart();
      Entity
        .With(x => x.isIgnitable = true);
    }
  }
}