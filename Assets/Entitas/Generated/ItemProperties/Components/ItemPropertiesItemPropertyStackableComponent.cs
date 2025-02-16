//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ItemPropertiesEntity {

    public Item.Property.StackableComponent itemPropertyStackable { get { return (Item.Property.StackableComponent)GetComponent(ItemPropertiesComponentsLookup.ItemPropertyStackable); } }
    public bool hasItemPropertyStackable { get { return HasComponent(ItemPropertiesComponentsLookup.ItemPropertyStackable); } }

    public void AddItemPropertyStackable(int newMaxStackSize) {
        var index = ItemPropertiesComponentsLookup.ItemPropertyStackable;
        var component = (Item.Property.StackableComponent)CreateComponent(index, typeof(Item.Property.StackableComponent));
        component.MaxStackSize = newMaxStackSize;
        AddComponent(index, component);
    }

    public void ReplaceItemPropertyStackable(int newMaxStackSize) {
        var index = ItemPropertiesComponentsLookup.ItemPropertyStackable;
        var component = (Item.Property.StackableComponent)CreateComponent(index, typeof(Item.Property.StackableComponent));
        component.MaxStackSize = newMaxStackSize;
        ReplaceComponent(index, component);
    }

    public void RemoveItemPropertyStackable() {
        RemoveComponent(ItemPropertiesComponentsLookup.ItemPropertyStackable);
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
public sealed partial class ItemPropertiesMatcher {

    static Entitas.IMatcher<ItemPropertiesEntity> _matcherItemPropertyStackable;

    public static Entitas.IMatcher<ItemPropertiesEntity> ItemPropertyStackable {
        get {
            if (_matcherItemPropertyStackable == null) {
                var matcher = (Entitas.Matcher<ItemPropertiesEntity>)Entitas.Matcher<ItemPropertiesEntity>.AllOf(ItemPropertiesComponentsLookup.ItemPropertyStackable);
                matcher.componentNames = ItemPropertiesComponentsLookup.componentNames;
                _matcherItemPropertyStackable = matcher;
            }

            return _matcherItemPropertyStackable;
        }
    }
}
