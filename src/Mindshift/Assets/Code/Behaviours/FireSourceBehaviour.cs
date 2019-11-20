using Assets.Code.Extensions;
using Assets.Code.Infrastructure;

namespace Assets.Code.Behaviours
{
  public class FireSourceBehaviour : EntityBehaviour
  {
    protected override void OnStart()
    {
      base.OnStart();
      Entity
        .With(x => x.isBurning = true);
    }
  }
}