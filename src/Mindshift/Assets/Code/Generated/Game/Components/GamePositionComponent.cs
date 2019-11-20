//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Assets.Code.Components.Position position { get { return (Assets.Code.Components.Position)GetComponent(GameComponentsLookup.Position); } }
    public UnityEngine.Vector3 Position { get { return position.Value; } }
    public bool hasPosition { get { return HasComponent(GameComponentsLookup.Position); } }

    public GameEntity AddPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Position;
        var component = (Assets.Code.Components.Position)CreateComponent(index, typeof(Assets.Code.Components.Position));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplacePosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Position;
        var component = (Assets.Code.Components.Position)CreateComponent(index, typeof(Assets.Code.Components.Position));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemovePosition() {
        RemoveComponent(GameComponentsLookup.Position);
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

    static Entitas.IMatcher<GameEntity> _matcherPosition;

    public static Entitas.IMatcher<GameEntity> Position {
        get {
            if (_matcherPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Position);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPosition = matcher;
            }

            return _matcherPosition;
        }
    }
}
