//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class DiedEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IDiedListener> _listenerBuffer;

    public DiedEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IDiedListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.Died)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.isDied && entity.hasDiedListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.diedListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnDied(e);
            }
        }
    }
}