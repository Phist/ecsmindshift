//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Assets.Code.Components.DurationUp durationUpComponent = new Assets.Code.Components.DurationUp();

    public bool isDurationUp {
        get { return HasComponent(GameComponentsLookup.DurationUp); }
        set {
            if (value != isDurationUp) {
                var index = GameComponentsLookup.DurationUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : durationUpComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherDurationUp;

    public static Entitas.IMatcher<GameEntity> DurationUp {
        get {
            if (_matcherDurationUp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DurationUp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDurationUp = matcher;
            }

            return _matcherDurationUp;
        }
    }
}
