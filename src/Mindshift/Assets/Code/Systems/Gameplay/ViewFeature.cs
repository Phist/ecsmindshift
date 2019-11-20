namespace Assets.Code.Systems.Gameplay
{
  public class ViewFeature : Feature
  {
    public ViewFeature(Contexts contexts)
      : base(nameof(ViewFeature))
    {
      //This system is unused in the demo but I left it as an example
      Add(new LoadViewSystem(contexts.game));
      
      Add(new DisplayHpSystem(contexts.game));
      
      Add(new BurnSpriteSystem(contexts.game));
      Add(new ExtinguishSpriteSystem(contexts.game));

      Add(new DestroyHittableSystem(contexts.game));
      Add(new DestroyBurntSystem(contexts.game));
    }
  }
}