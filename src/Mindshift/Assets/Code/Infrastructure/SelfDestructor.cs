using Entitas.VisualDebugging.Unity;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
  public class SelfDestructor : MonoBehaviour
  {
    public float Countdown = 3.0f;

    private void Update()
    {
      Countdown -= Time.deltaTime;
      if (Countdown <= 0)
        gameObject.DestroyGameObject();
    }
  }
}