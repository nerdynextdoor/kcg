//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ItemPropertiesEntity {

    static readonly Item.Property.EquipmentComponent itemPropertyEquipmentComponent = new Item.Property.EquipmentComponent();

    public bool isItemPropertyEquipment {
        get { return HasComponent(ItemPropertiesComponentsLookup.ItemPropertyEquipment); }
        set {
            if (value != isItemPropertyEquipment) {
                var index = ItemPropertiesComponentsLookup.ItemPropertyEquipment;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : itemPropertyEquipmentComponent;

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
public sealed partial class ItemPropertiesMatcher {

    static Entitas.IMatcher<ItemPropertiesEntity> _matcherItemPropertyEquipment;

    public static Entitas.IMatcher<ItemPropertiesEntity> ItemPropertyEquipment {
        get {
            if (_matcherItemPropertyEquipment == null) {
                var matcher = (Entitas.Matcher<ItemPropertiesEntity>)Entitas.Matcher<ItemPropertiesEntity>.AllOf(ItemPropertiesComponentsLookup.ItemPropertyEquipment);
                matcher.componentNames = ItemPropertiesComponentsLookup.componentNames;
                _matcherItemPropertyEquipment = matcher;
            }

            return _matcherItemPropertyEquipment;
        }
    }
}
