using Assets.Code.Systems.Gameplay.HumanSpawn;
using Assets.Code.Systems.Gameplay.Input;
using Code.Systems.Gameplay.Hero;

namespace Assets.Code.Systems.Gameplay
{
  public class GameplaySystems : Feature
  {
    public GameplaySystems(Contexts contexts) : base(nameof(GameplaySystems))
    {
      Add(new InputSystems(contexts));

      Add(new DurationSystem(contexts.game));
      Add(new BurnHpSystem(contexts.game, 1));
      
      Add(new IgniteFromBurningOnCollision(contexts.game));
      
      Add(new ExtinguishOnDurationUp(contexts.game));

      Add(new HeroFeature(contexts));
      Add(new ViewFeature(contexts));

      Add(new ResetCollidedSystem(contexts.game));
      Add(new CleanupDestructed(contexts.game));
    }
  }
}