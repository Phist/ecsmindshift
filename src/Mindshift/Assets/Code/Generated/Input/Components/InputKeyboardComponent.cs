//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity keyboardEntity { get { return GetGroup(InputMatcher.Keyboard).GetSingleEntity(); } }

    public bool isKeyboard {
        get { return keyboardEntity != null; }
        set {
            var entity = keyboardEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isKeyboard = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly Assets.Code.Components.Keyboard keyboardComponent = new Assets.Code.Components.Keyboard();

    public bool isKeyboard {
        get { return HasComponent(InputComponentsLookup.Keyboard); }
        set {
            if (value != isKeyboard) {
                var index = InputComponentsLookup.Keyboard;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : keyboardComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherKeyboard;

    public static Entitas.IMatcher<InputEntity> Keyboard {
        get {
            if (_matcherKeyboard == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Keyboard);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherKeyboard = matcher;
            }

            return _matcherKeyboard;
        }
    }
}
