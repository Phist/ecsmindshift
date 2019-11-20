//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public JumpingListenerComponent jumpingListener { get { return (JumpingListenerComponent)GetComponent(GameComponentsLookup.JumpingListener); } }
    public bool hasJumpingListener { get { return HasComponent(GameComponentsLookup.JumpingListener); } }

    public GameEntity AddJumpingListener(System.Collections.Generic.List<IJumpingListener> newValue) {
        var index = GameComponentsLookup.JumpingListener;
        var component = (JumpingListenerComponent)CreateComponent(index, typeof(JumpingListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceJumpingListener(System.Collections.Generic.List<IJumpingListener> newValue) {
        var index = GameComponentsLookup.JumpingListener;
        var component = (JumpingListenerComponent)CreateComponent(index, typeof(JumpingListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveJumpingListener() {
        RemoveComponent(GameComponentsLookup.JumpingListener);
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

    static Entitas.IMatcher<GameEntity> _matcherJumpingListener;

    public static Entitas.IMatcher<GameEntity> JumpingListener {
        get {
            if (_matcherJumpingListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JumpingListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJumpingListener = matcher;
            }

            return _matcherJumpingListener;
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

    public void AddJumpingListener(IJumpingListener value) {
        var listeners = hasJumpingListener
            ? jumpingListener.value
            : new System.Collections.Generic.List<IJumpingListener>();
        listeners.Add(value);
        ReplaceJumpingListener(listeners);
    }

    public void RemoveJumpingListener(IJumpingListener value, bool removeComponentWhenEmpty = true) {
        var listeners = jumpingListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveJumpingListener();
        } else {
            ReplaceJumpingListener(listeners);
        }
    }
}
