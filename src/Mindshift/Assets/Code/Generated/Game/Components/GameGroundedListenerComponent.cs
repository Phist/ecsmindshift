//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GroundedListenerComponent groundedListener { get { return (GroundedListenerComponent)GetComponent(GameComponentsLookup.GroundedListener); } }
    public bool hasGroundedListener { get { return HasComponent(GameComponentsLookup.GroundedListener); } }

    public GameEntity AddGroundedListener(System.Collections.Generic.List<IGroundedListener> newValue) {
        var index = GameComponentsLookup.GroundedListener;
        var component = (GroundedListenerComponent)CreateComponent(index, typeof(GroundedListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceGroundedListener(System.Collections.Generic.List<IGroundedListener> newValue) {
        var index = GameComponentsLookup.GroundedListener;
        var component = (GroundedListenerComponent)CreateComponent(index, typeof(GroundedListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveGroundedListener() {
        RemoveComponent(GameComponentsLookup.GroundedListener);
        return this;
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGroundedListener;

    public static Entitas.IMatcher<GameEntity> GroundedListener {
        get {
            if (_matcherGroundedListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GroundedListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGroundedListener = matcher;
            }

            return _matcherGroundedListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddGroundedListener(IGroundedListener value) {
        var listeners = hasGroundedListener
            ? groundedListener.value
            : new System.Collections.Generic.List<IGroundedListener>();
        listeners.Add(value);
        ReplaceGroundedListener(listeners);
    }

    public void RemoveGroundedListener(IGroundedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = groundedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGroundedListener();
        } else {
            ReplaceGroundedListener(listeners);
        }
    }
}
