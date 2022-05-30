//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Components.ItemMoveComponent itemMove { get { return (Components.ItemMoveComponent)GetComponent(GameComponentsLookup.ItemMove); } }
    public bool hasItemMove { get { return HasComponent(GameComponentsLookup.ItemMove); } }

    public void AddItemMove(float newPreviuosPosX, float newPreviuosPosY) {
        var index = GameComponentsLookup.ItemMove;
        var component = (Components.ItemMoveComponent)CreateComponent(index, typeof(Components.ItemMoveComponent));
        component.PreviuosPosX = newPreviuosPosX;
        component.PreviuosPosY = newPreviuosPosY;
        AddComponent(index, component);
    }

    public void ReplaceItemMove(float newPreviuosPosX, float newPreviuosPosY) {
        var index = GameComponentsLookup.ItemMove;
        var component = (Components.ItemMoveComponent)CreateComponent(index, typeof(Components.ItemMoveComponent));
        component.PreviuosPosX = newPreviuosPosX;
        component.PreviuosPosY = newPreviuosPosY;
        ReplaceComponent(index, component);
    }

    public void RemoveItemMove() {
        RemoveComponent(GameComponentsLookup.ItemMove);
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

    static Entitas.IMatcher<GameEntity> _matcherItemMove;

    public static Entitas.IMatcher<GameEntity> ItemMove {
        get {
            if (_matcherItemMove == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ItemMove);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherItemMove = matcher;
            }

            return _matcherItemMove;
        }
    }
}
