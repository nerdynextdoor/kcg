//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Entities.VehicleEntity vehicleEntityComponent = new Entities.VehicleEntity();

    public bool isVehicleEntity {
        get { return HasComponent(GameComponentsLookup.VehicleEntity); }
        set {
            if (value != isVehicleEntity) {
                var index = GameComponentsLookup.VehicleEntity;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : vehicleEntityComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherVehicleEntity;

    public static Entitas.IMatcher<GameEntity> VehicleEntity {
        get {
            if (_matcherVehicleEntity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VehicleEntity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVehicleEntity = matcher;
            }

            return _matcherVehicleEntity;
        }
    }
}
