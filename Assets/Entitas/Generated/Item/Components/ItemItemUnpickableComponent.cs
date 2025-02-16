//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ItemEntity {

    static readonly Item.Unpickable itemUnpickableComponent = new Item.Unpickable();

    public bool isItemUnpickable {
        get { return HasComponent(ItemComponentsLookup.ItemUnpickable); }
        set {
            if (value != isItemUnpickable) {
                var index = ItemComponentsLookup.ItemUnpickable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : itemUnpickableComponent;

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
public sealed partial class ItemMatcher {

    static Entitas.IMatcher<ItemEntity> _matcherItemUnpickable;

    public static Entitas.IMatcher<ItemEntity> ItemUnpickable {
        get {
            if (_matcherItemUnpickable == null) {
                var matcher = (Entitas.Matcher<ItemEntity>)Entitas.Matcher<ItemEntity>.AllOf(ItemComponentsLookup.ItemUnpickable);
                matcher.componentNames = ItemComponentsLookup.componentNames;
                _matcherItemUnpickable = matcher;
            }

            return _matcherItemUnpickable;
        }
    }
}
