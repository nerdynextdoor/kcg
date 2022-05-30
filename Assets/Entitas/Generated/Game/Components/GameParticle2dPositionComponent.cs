//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Components.Particle2dPositionComponent particle2dPosition { get { return (Components.Particle2dPositionComponent)GetComponent(GameComponentsLookup.Particle2dPosition); } }
    public bool hasParticle2dPosition { get { return HasComponent(GameComponentsLookup.Particle2dPosition); } }

    public void AddParticle2dPosition(UnityEngine.Vector2 newPosition, UnityEngine.Vector2 newAcceleration, UnityEngine.Vector2 newVelocity) {
        var index = GameComponentsLookup.Particle2dPosition;
        var component = (Components.Particle2dPositionComponent)CreateComponent(index, typeof(Components.Particle2dPositionComponent));
        component.Position = newPosition;
        component.Acceleration = newAcceleration;
        component.Velocity = newVelocity;
        AddComponent(index, component);
    }

    public void ReplaceParticle2dPosition(UnityEngine.Vector2 newPosition, UnityEngine.Vector2 newAcceleration, UnityEngine.Vector2 newVelocity) {
        var index = GameComponentsLookup.Particle2dPosition;
        var component = (Components.Particle2dPositionComponent)CreateComponent(index, typeof(Components.Particle2dPositionComponent));
        component.Position = newPosition;
        component.Acceleration = newAcceleration;
        component.Velocity = newVelocity;
        ReplaceComponent(index, component);
    }

    public void RemoveParticle2dPosition() {
        RemoveComponent(GameComponentsLookup.Particle2dPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherParticle2dPosition;

    public static Entitas.IMatcher<GameEntity> Particle2dPosition {
        get {
            if (_matcherParticle2dPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Particle2dPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherParticle2dPosition = matcher;
            }

            return _matcherParticle2dPosition;
        }
    }
}
