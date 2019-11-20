using Assets.Code.Infrastructure;
using UnityEngine.UI;

namespace Assets.Code.Behaviours
{
  public class HpBarBehaviour : EntityBehaviour
  {
    public Image ImValue;
    
    protected override void OnStart()
    {
      Entity
        .AddImage(ImValue)
        .isHpBar = true;
    }
  }
}