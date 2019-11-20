using Entitas;

namespace Assets.Code.Systems
{
  public abstract class TimerExecuteSystem : IExecuteSystem
  {
    private float _timeToNextExecute;
    private readonly float _executeIntervalInSeconds;

    protected TimerExecuteSystem(float executeIntervalInSeconds)
    {
      _executeIntervalInSeconds = executeIntervalInSeconds;
    }

    protected abstract void Execute();

    void IExecuteSystem.Execute()
    {
      _timeToNextExecute -= Contexts.sharedInstance.game.Time.DeltaTime;
      if (_timeToNextExecute > 0)
        return;

      _timeToNextExecute = _executeIntervalInSeconds;

      this.Execute();
    }
  }
}