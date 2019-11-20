using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class LayerListener : MonoBehaviour, ILayerListener, IEventListener
  {
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity)entity;
      _entity.AddLayerListener(this);

      gameObject.layer = LayerMask.NameToLayer(_entity.Layer.ToString());
    }

    public void UnregisterListeners(IEntity with) => 
      _entity.RemoveLayerListener(this);

    public void OnLayer(GameEntity entity, CollisionLayer value)
    {
      int layer = LayerMask.NameToLayer(value.ToString());
      gameObject.layer = layer;
    }
  }
}