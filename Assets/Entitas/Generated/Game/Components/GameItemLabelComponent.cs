//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Item.LabelComponent itemLabel { get { return (Item.LabelComponent)GetComponent(GameComponentsLookup.ItemLabel); } }
    public bool hasItemLabel { get { return HasComponent(GameComponentsLookup.ItemLabel); } }

    public void AddItemLabel(string newItemName) {
        var index = GameComponentsLookup.ItemLabel;
        var component = (Item.LabelComponent)CreateComponent(index, typeof(Item.LabelComponent));
        component.ItemName = newItemName;
        AddComponent(index, component);
    }

    public void ReplaceItemLabel(string newItemName) {
        var index = GameComponentsLookup.ItemLabel;
        var component = (Item.LabelComponent)CreateComponent(index, typeof(Item.LabelComponent));
        component.ItemName = newItemName;
        ReplaceComponent(index, component);
    }

    public void RemoveItemLabel() {
        RemoveComponent(GameComponentsLookup.ItemLabel);
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

    static Entitas.IMatcher<GameEntity> _matcherItemLabel;

    public static Entitas.IMatcher<GameEntity> ItemLabel {
        get {
            if (_matcherItemLabel == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ItemLabel);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherItemLabel = matcher;
            }

            return _matcherItemLabel;
        }
    }
}
