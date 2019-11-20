//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DamageTakenListenerComponent damageTakenListener { get { return (DamageTakenListenerComponent)GetComponent(GameComponentsLookup.DamageTakenListener); } }
    public bool hasDamageTakenListener { get { return HasComponent(GameComponentsLookup.DamageTakenListener); } }

    public GameEntity AddDamageTakenListener(System.Collections.Generic.List<IDamageTakenListener> newValue) {
        var index = GameComponentsLookup.DamageTakenListener;
        var component = (DamageTakenListenerComponent)CreateComponent(index, typeof(DamageTakenListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDamageTakenListener(System.Collections.Generic.List<IDamageTakenListener> newValue) {
        var index = GameComponentsLookup.DamageTakenListener;
        var component = (DamageTakenListenerComponent)CreateComponent(index, typeof(DamageTakenListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDamageTakenListener() {
        RemoveComponent(GameComponentsLookup.DamageTakenListener);
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

    static Entitas.IMatcher<GameEntity> _matcherDamageTakenListener;

    public static Entitas.IMatcher<GameEntity> DamageTakenListener {
        get {
            if (_matcherDamageTakenListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DamageTakenListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDamageTakenListener = matcher;
            }

            return _matcherDamageTakenListener;
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

    public void AddDamageTakenListener(IDamageTakenListener value) {
        var listeners = hasDamageTakenListener
            ? damageTakenListener.value
            : new System.Collections.Generic.List<IDamageTakenListener>();
        listeners.Add(value);
        ReplaceDamageTakenListener(listeners);
    }

    public void RemoveDamageTakenListener(IDamageTakenListener value, bool removeComponentWhenEmpty = true) {
        var listeners = damageTakenListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveDamageTakenListener();
        } else {
            ReplaceDamageTakenListener(listeners);
        }
    }
}
