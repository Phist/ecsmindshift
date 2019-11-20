using Entitas;
using UnityEngine;

namespace Assets.Code.ViewListeners
{
  public class PositionListener : MonoBehaviour, IPositionListener, ILastUpdatedPositionListener, IEventListener
  {
    private GameEntity _entity;
    private Rigidbody2D _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    public void OnPosition(GameEntity entity, Vector3 value)
    {
      if (_rigidbody != null)
        _rigidbody.position = value;
      else
        transform.position = value;
    }

    public void RegisterListeners(IEntity entity)
    {
      _entity = (GameEntity) entity;
      _entity.AddPositionListener(this);
      _entity.AddLastUpdatedPositionListener(this);
      
      if (_entity.hasPosition)
        OnPosition(_entity, _entity.Position);
    }

    public void UnregisterListeners(IEntity with)
    {
      _entity.RemovePositionListener(this);
      _entity.RemoveLastUpdatedPositionListener(this);
    }

    public void OnLastUpdatedPosition(GameEntity entity, Vector3 value)
    {
    }

    private void LateUpdate()
    {
      if (!_entity.isEnabled)
        return;

      if (_rigidbody != null)
        _entity.ReplaceLastUpdatedPosition(_rigidbody.position);
      else
        _entity.ReplaceLastUpdatedPosition(transform.position);
    }
  }
}