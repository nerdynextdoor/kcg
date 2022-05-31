//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Components.ParticleStateComponent particleState { get { return (Components.ParticleStateComponent)GetComponent(GameComponentsLookup.ParticleState); } }
    public bool hasParticleState { get { return HasComponent(GameComponentsLookup.ParticleState); } }

    public void AddParticleState(UnityEngine.GameObject newGameObject, float newHealth, float newDecayRate, float newDeltaRotation, float newDeltaScale) {
        var index = GameComponentsLookup.ParticleState;
        var component = (Components.ParticleStateComponent)CreateComponent(index, typeof(Components.ParticleStateComponent));
        component.GameObject = newGameObject;
        component.Health = newHealth;
        component.DecayRate = newDecayRate;
        component.DeltaRotation = newDeltaRotation;
        component.DeltaScale = newDeltaScale;
        AddComponent(index, component);
    }

    public void ReplaceParticleState(UnityEngine.GameObject newGameObject, float newHealth, float newDecayRate, float newDeltaRotation, float newDeltaScale) {
        var index = GameComponentsLookup.ParticleState;
        var component = (Components.ParticleStateComponent)CreateComponent(index, typeof(Components.ParticleStateComponent));
        component.GameObject = newGameObject;
        component.Health = newHealth;
        component.DecayRate = newDecayRate;
        component.DeltaRotation = newDeltaRotation;
        component.DeltaScale = newDeltaScale;
        ReplaceComponent(index, component);
    }

    public void RemoveParticleState() {
        RemoveComponent(GameComponentsLookup.ParticleState);
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

    static Entitas.IMatcher<GameEntity> _matcherParticleState;

    public static Entitas.IMatcher<GameEntity> ParticleState {
        get {
            if (_matcherParticleState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ParticleState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherParticleState = matcher;
            }

            return _matcherParticleState;
        }
    }
}
