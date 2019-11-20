using System.Collections;
using UnityEngine;

namespace Assets.Code.Services
{
  public class UnityCoroutineDirectorService : ICoroutineDirectorService
  {
    private readonly MonoBehaviour _monoBehaviour;

    public UnityCoroutineDirectorService(MonoBehaviour monoBehaviour) => 
      _monoBehaviour = monoBehaviour;

    public Coroutine Start(IEnumerator сoroutine) => 
      _monoBehaviour.StartCoroutine(сoroutine);
  }
}