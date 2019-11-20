namespace Assets.Code.Common
{
  public static class StaticCleaners
  {
    public static GameContext Game() => Contexts.sharedInstance.game;
  }
}
