using Entitas;

namespace Assets.Code.Systems.Gameplay.Input
{
  public class RegisterInputsSystem : IInitializeSystem
  {
    private readonly InputContext _input;

    public RegisterInputsSystem(InputContext input) => _input = input;

    public void Initialize()
    {
      _input.isLeftMouse = true;
      _input.isRightMouse = true;
      _input.isKeyboard = true;
    }
  }
}