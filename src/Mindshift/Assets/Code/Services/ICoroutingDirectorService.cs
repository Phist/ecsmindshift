using System.Collections;
using UnityEngine;

namespace Assets.Code.Services
{
  public interface ICoroutineDirectorService
  {
    Coroutine Start(IEnumerator сoroutine);
  }
}