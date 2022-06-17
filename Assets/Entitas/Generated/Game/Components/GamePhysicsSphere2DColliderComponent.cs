//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Physics.Sphere2DColliderComponent physicsSphere2DCollider { get { return (Physics.Sphere2DColliderComponent)GetComponent(GameComponentsLookup.PhysicsSphere2DCollider); } }
    public bool hasPhysicsSphere2DCollider { get { return HasComponent(GameComponentsLookup.PhysicsSphere2DCollider); } }

    public void AddPhysicsSphere2DCollider(float newRadius, KMath.Vec2f newSize) {
        var index = GameComponentsLookup.PhysicsSphere2DCollider;
        var component = (Physics.Sphere2DColliderComponent)CreateComponent(index, typeof(Physics.Sphere2DColliderComponent));
        component.Radius = newRadius;
        component.Size = newSize;
        AddComponent(index, component);
    }

    public void ReplacePhysicsSphere2DCollider(float newRadius, KMath.Vec2f newSize) {
        var index = GameComponentsLookup.PhysicsSphere2DCollider;
        var component = (Physics.Sphere2DColliderComponent)CreateComponent(index, typeof(Physics.Sphere2DColliderComponent));
        component.Radius = newRadius;
        component.Size = newSize;
        ReplaceComponent(index, component);
    }

    public void RemovePhysicsSphere2DCollider() {
        RemoveComponent(GameComponentsLookup.PhysicsSphere2DCollider);
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

    static Entitas.IMatcher<GameEntity> _matcherPhysicsSphere2DCollider;

    public static Entitas.IMatcher<GameEntity> PhysicsSphere2DCollider {
        get {
            if (_matcherPhysicsSphere2DCollider == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PhysicsSphere2DCollider);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPhysicsSphere2DCollider = matcher;
            }

            return _matcherPhysicsSphere2DCollider;
        }
    }
}
