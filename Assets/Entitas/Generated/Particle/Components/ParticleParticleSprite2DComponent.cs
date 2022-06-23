//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ParticleEntity {

    public Particle.Sprite2DComponent particleSprite2D { get { return (Particle.Sprite2DComponent)GetComponent(ParticleComponentsLookup.ParticleSprite2D); } }
    public bool hasParticleSprite2D { get { return HasComponent(ParticleComponentsLookup.ParticleSprite2D); } }

    public void AddParticleSprite2D(int newSpriteId, KMath.Vec2f newSize) {
        var index = ParticleComponentsLookup.ParticleSprite2D;
        var component = (Particle.Sprite2DComponent)CreateComponent(index, typeof(Particle.Sprite2DComponent));
        component.SpriteId = newSpriteId;
        component.Size = newSize;
        AddComponent(index, component);
    }

    public void ReplaceParticleSprite2D(int newSpriteId, KMath.Vec2f newSize) {
        var index = ParticleComponentsLookup.ParticleSprite2D;
        var component = (Particle.Sprite2DComponent)CreateComponent(index, typeof(Particle.Sprite2DComponent));
        component.SpriteId = newSpriteId;
        component.Size = newSize;
        ReplaceComponent(index, component);
    }

    public void RemoveParticleSprite2D() {
        RemoveComponent(ParticleComponentsLookup.ParticleSprite2D);
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
public sealed partial class ParticleMatcher {

    static Entitas.IMatcher<ParticleEntity> _matcherParticleSprite2D;

    public static Entitas.IMatcher<ParticleEntity> ParticleSprite2D {
        get {
            if (_matcherParticleSprite2D == null) {
                var matcher = (Entitas.Matcher<ParticleEntity>)Entitas.Matcher<ParticleEntity>.AllOf(ParticleComponentsLookup.ParticleSprite2D);
                matcher.componentNames = ParticleComponentsLookup.componentNames;
                _matcherParticleSprite2D = matcher;
            }

            return _matcherParticleSprite2D;
        }
    }
}
