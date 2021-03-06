//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Assets.Code.Components.LastUpdatedPosition lastUpdatedPosition { get { return (Assets.Code.Components.LastUpdatedPosition)GetComponent(GameComponentsLookup.LastUpdatedPosition); } }
    public UnityEngine.Vector3 LastUpdatedPosition { get { return lastUpdatedPosition.Value; } }
    public bool hasLastUpdatedPosition { get { return HasComponent(GameComponentsLookup.LastUpdatedPosition); } }

    public GameEntity AddLastUpdatedPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.LastUpdatedPosition;
        var component = (Assets.Code.Components.LastUpdatedPosition)CreateComponent(index, typeof(Assets.Code.Components.LastUpdatedPosition));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLastUpdatedPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.LastUpdatedPosition;
        var component = (Assets.Code.Components.LastUpdatedPosition)CreateComponent(index, typeof(Assets.Code.Components.LastUpdatedPosition));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLastUpdatedPosition() {
        RemoveComponent(GameComponentsLookup.LastUpdatedPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherLastUpdatedPosition;

    public static Entitas.IMatcher<GameEntity> LastUpdatedPosition {
        get {
            if (_matcherLastUpdatedPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LastUpdatedPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLastUpdatedPosition = matcher;
            }

            return _matcherLastUpdatedPosition;
        }
    }
}
