//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Physics.Circle2DColliderComponent physicsCircle2DCollider { get { return (Physics.Circle2DColliderComponent)GetComponent(GameComponentsLookup.PhysicsCircle2DCollider); } }
    public bool hasPhysicsCircle2DCollider { get { return HasComponent(GameComponentsLookup.PhysicsCircle2DCollider); } }

    public void AddPhysicsCircle2DCollider(float newRadius) {
        var index = GameComponentsLookup.PhysicsCircle2DCollider;
        var component = (Physics.Circle2DColliderComponent)CreateComponent(index, typeof(Physics.Circle2DColliderComponent));
        component.Radius = newRadius;
        AddComponent(index, component);
    }

    public void ReplacePhysicsCircle2DCollider(float newRadius) {
        var index = GameComponentsLookup.PhysicsCircle2DCollider;
        var component = (Physics.Circle2DColliderComponent)CreateComponent(index, typeof(Physics.Circle2DColliderComponent));
        component.Radius = newRadius;
        ReplaceComponent(index, component);
    }

    public void RemovePhysicsCircle2DCollider() {
        RemoveComponent(GameComponentsLookup.PhysicsCircle2DCollider);
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

    static Entitas.IMatcher<GameEntity> _matcherPhysicsCircle2DCollider;

    public static Entitas.IMatcher<GameEntity> PhysicsCircle2DCollider {
        get {
            if (_matcherPhysicsCircle2DCollider == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PhysicsCircle2DCollider);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPhysicsCircle2DCollider = matcher;
            }

            return _matcherPhysicsCircle2DCollider;
        }
    }
}
