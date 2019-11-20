using UnityEngine;

namespace Assets.Code.Services
{
  public interface IInputService
  {
    float Horizontal { get; }
    float Jump { get; }

    Vector2 GetScreenMousePosition();
    Vector3 GetWorldMousePosition();

    bool GetLeftMouseButton();
    bool GetLeftMouseButtonDown();
    bool GetLeftMouseButtonUp();

    bool GetRightMouseButton();
    bool GetRightMouseButtonDown();
    bool GetRightMouseButtonUp();
  }
}