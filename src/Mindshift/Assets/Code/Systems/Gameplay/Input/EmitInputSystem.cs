using Assets.Code.Extensions;
using Assets.Code.Services;
using Entitas;
using UnityEngine;

namespace Assets.Code.Systems.Gameplay.Input
{
  public class EmitInputSystem : IExecuteSystem
  {
    private readonly InputContext _inputContext;
    private readonly IGroup<InputEntity> _leftMouse;
    private readonly IGroup<InputEntity> _rightMouse;
    private IInputService Input => _inputContext.Input;
    private readonly IGroup<InputEntity> _keyboard;

    public EmitInputSystem(InputContext inputContext)
    {
      _inputContext = inputContext;
      _leftMouse = inputContext.GetGroup(InputMatcher.LeftMouse);
      _rightMouse = inputContext.GetGroup(InputMatcher.RightMouse);
      _keyboard = inputContext.GetGroup(InputMatcher.Keyboard);
    }

    public void Execute()
    {
      foreach (InputEntity leftMouse in _leftMouse)
      foreach (InputEntity rightMouse in _rightMouse)
      foreach (InputEntity keyboard in _keyboard)
      {
        Vector2 screenPosition = Input.GetScreenMousePosition();
        Vector2 worldPosition = Input.GetWorldMousePosition();

        leftMouse.isMouseDown = Input.GetLeftMouseButtonDown();
        leftMouse.isMouse = Input.GetLeftMouseButton();
        leftMouse.Do(l => l.ReplaceMouseScreenPosition(screenPosition), when: Input.GetLeftMouseButton());
        leftMouse.Do(l => l.ReplaceMouseWorldPosition(worldPosition), when: Input.GetLeftMouseButton());
        leftMouse.isMouseUp = Input.GetLeftMouseButtonUp();

        rightMouse.isMouseDown = Input.GetRightMouseButtonDown();        
        rightMouse.isMouse = Input.GetRightMouseButton();
        rightMouse.Do(r => r.ReplaceMouseScreenPosition(screenPosition), when: Input.GetRightMouseButton());
        rightMouse.Do(r => r.ReplaceMouseWorldPosition(worldPosition), when: Input.GetRightMouseButton());
        rightMouse.isMouseUp = Input.GetRightMouseButtonUp();

        keyboard.ReplaceHorizontal(Input.Horizontal);
        keyboard.isJump = Input.Jump > 0;
      }
    }
  }
}