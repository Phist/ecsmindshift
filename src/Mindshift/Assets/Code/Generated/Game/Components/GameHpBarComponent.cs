//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Assets.Code.Components.HpBar hpBarComponent = new Assets.Code.Components.HpBar();

    public bool isHpBar {
        get { return HasComponent(GameComponentsLookup.HpBar); }
        set {
            if (value != isHpBar) {
                var index = GameComponentsLookup.HpBar;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : hpBarComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherHpBar;

    public static Entitas.IMatcher<GameEntity> HpBar {
        get {
            if (_matcherHpBar == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HpBar);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHpBar = matcher;
            }

            return _matcherHpBar;
        }
    }
}
