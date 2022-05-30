//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Components.ItemComponent item { get { return (Components.ItemComponent)GetComponent(GameComponentsLookup.Item); } }
    public bool hasItem { get { return HasComponent(GameComponentsLookup.Item); } }

    public void AddItem(string newLabel, int newSpriteID, Enums.ItemType newItemType) {
        var index = GameComponentsLookup.Item;
        var component = (Components.ItemComponent)CreateComponent(index, typeof(Components.ItemComponent));
        component.Label = newLabel;
        component.SpriteID = newSpriteID;
        component.ItemType = newItemType;
        AddComponent(index, component);
    }

    public void ReplaceItem(string newLabel, int newSpriteID, Enums.ItemType newItemType) {
        var index = GameComponentsLookup.Item;
        var component = (Components.ItemComponent)CreateComponent(index, typeof(Components.ItemComponent));
        component.Label = newLabel;
        component.SpriteID = newSpriteID;
        component.ItemType = newItemType;
        ReplaceComponent(index, component);
    }

    public void RemoveItem() {
        RemoveComponent(GameComponentsLookup.Item);
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

    static Entitas.IMatcher<GameEntity> _matcherItem;

    public static Entitas.IMatcher<GameEntity> Item {
        get {
            if (_matcherItem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Item);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherItem = matcher;
            }

            return _matcherItem;
        }
    }
}
