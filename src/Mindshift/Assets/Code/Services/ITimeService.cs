using System;

namespace Assets.Code.Services
{
  public interface ITimeService
  {
    float DeltaTime { get; }
    float InGameTime { get; }
    DateTime UtcNow { get; }
  }
}