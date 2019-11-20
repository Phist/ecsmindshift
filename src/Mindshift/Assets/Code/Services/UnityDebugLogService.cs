using UnityEngine;

namespace Assets.Code.Services
{
  public class UnityDebugLogService : ILogService
  {
    public void LogMessage(string message) => Debug.Log(message);
  }
}