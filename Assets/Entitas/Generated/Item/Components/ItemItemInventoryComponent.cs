//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ItemEntity {

    public Item.InventoryComponent itemInventory { get { return (Item.InventoryComponent)GetComponent(ItemComponentsLookup.ItemInventory); } }
    public bool hasItemInventory { get { return HasComponent(ItemComponentsLookup.ItemInventory); } }

    public void AddItemInventory(int newInventoryID) {
        var index = ItemComponentsLookup.ItemInventory;
        var component = (Item.InventoryComponent)CreateComponent(index, typeof(Item.InventoryComponent));
        component.InventoryID = newInventoryID;
        AddComponent(index, component);
    }

    public void ReplaceItemInventory(int newInventoryID) {
        var index = ItemComponentsLookup.ItemInventory;
        var component = (Item.InventoryComponent)CreateComponent(index, typeof(Item.InventoryComponent));
        component.InventoryID = newInventoryID;
        ReplaceComponent(index, component);
    }

    public void RemoveItemInventory() {
        RemoveComponent(ItemComponentsLookup.ItemInventory);
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

    static Entitas.IMatcher<ItemEntity> _matcherItemInventory;

    public static Entitas.IMatcher<ItemEntity> ItemInventory {
        get {
            if (_matcherItemInventory == null) {
                var matcher = (Entitas.Matcher<ItemEntity>)Entitas.Matcher<ItemEntity>.AllOf(ItemComponentsLookup.ItemInventory);
                matcher.componentNames = ItemComponentsLookup.componentNames;
                _matcherItemInventory = matcher;
            }

            return _matcherItemInventory;
        }
    }
}
