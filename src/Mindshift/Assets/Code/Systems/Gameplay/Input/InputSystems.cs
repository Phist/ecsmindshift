namespace Assets.Code.Systems.Gameplay.Input
{
  public class InputSystems : Feature
  {
    public InputSystems(Contexts contexts) : base(nameof(InputSystems))
    {
      Add(new RegisterInputsSystem(contexts.input));
     
      Add(new EmitInputSystem(contexts.input));
    }
  }
}