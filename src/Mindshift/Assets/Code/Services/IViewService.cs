using Assets.Code.ViewListeners;
using Entitas;
using UnityEngine;

namespace Assets.Code.Services
{
  public interface IViewService
  {
    void CreateView<T>(GameContext game, IEntity entity, string name) where T : Component, IViewController;
    void LoadView<T>(GameContext game, IEntity entity, string name) where T : Component, IViewController;
    void BindExistingView<T>(GameContext game, IEntity entity, string name) where T : Component, IViewController;
  }
}