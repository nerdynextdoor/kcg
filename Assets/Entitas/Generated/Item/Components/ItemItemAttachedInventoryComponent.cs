//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ItemEntity {

    public Item.AttachedInventoryComponent itemAttachedInventory { get { return (Item.AttachedInventoryComponent)GetComponent(ItemComponentsLookup.ItemAttachedInventory); } }
    public bool hasItemAttachedInventory { get { return HasComponent(ItemComponentsLookup.ItemAttachedInventory); } }

    public void AddItemAttachedInventory(int newInventoryID, int newSlotNumber) {
        var index = ItemComponentsLookup.ItemAttachedInventory;
        var component = (Item.AttachedInventoryComponent)CreateComponent(index, typeof(Item.AttachedInventoryComponent));
        component.InventoryID = newInventoryID;
        component.SlotNumber = newSlotNumber;
        AddComponent(index, component);
    }

    public void ReplaceItemAttachedInventory(int newInventoryID, int newSlotNumber) {
        var index = ItemComponentsLookup.ItemAttachedInventory;
        var component = (Item.AttachedInventoryComponent)CreateComponent(index, typeof(Item.AttachedInventoryComponent));
        component.InventoryID = newInventoryID;
        component.SlotNumber = newSlotNumber;
        ReplaceComponent(index, component);
    }

    public void RemoveItemAttachedInventory() {
        RemoveComponent(ItemComponentsLookup.ItemAttachedInventory);
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

    static Entitas.IMatcher<ItemEntity> _matcherItemAttachedInventory;

    public static Entitas.IMatcher<ItemEntity> ItemAttachedInventory {
        get {
            if (_matcherItemAttachedInventory == null) {
                var matcher = (Entitas.Matcher<ItemEntity>)Entitas.Matcher<ItemEntity>.AllOf(ItemComponentsLookup.ItemAttachedInventory);
                matcher.componentNames = ItemComponentsLookup.componentNames;
                _matcherItemAttachedInventory = matcher;
            }

            return _matcherItemAttachedInventory;
        }
    }
}
