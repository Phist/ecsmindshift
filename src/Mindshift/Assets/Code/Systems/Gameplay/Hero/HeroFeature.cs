namespace Code.Systems.Gameplay.Hero
{
  public sealed class HeroFeature : Feature
  {
    public HeroFeature(Contexts contexts)
    {
      Add(new HeroAirborneSystem(contexts.game));
      Add(new MoveHeroSystem(contexts.game, contexts.input));
      Add(new HeroJumpSystem(contexts.game, contexts.input));
      Add(new HeroAttackSystem(contexts.game, contexts.input));
      Add(new HeroGroundedSystem(contexts.game));
    }
  }
}