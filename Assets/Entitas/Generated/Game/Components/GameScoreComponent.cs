//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ScoreComponent score { get { return (ScoreComponent)GetComponent(GameComponentsLookup.Score); } }
    public bool hasScore { get { return HasComponent(GameComponentsLookup.Score); } }

    public void AddScore(int newScore) {
        var index = GameComponentsLookup.Score;
        var component = (ScoreComponent)CreateComponent(index, typeof(ScoreComponent));
        component.score = newScore;
        AddComponent(index, component);
    }

    public void ReplaceScore(int newScore) {
        var index = GameComponentsLookup.Score;
        var component = (ScoreComponent)CreateComponent(index, typeof(ScoreComponent));
        component.score = newScore;
        ReplaceComponent(index, component);
    }

    public void RemoveScore() {
        RemoveComponent(GameComponentsLookup.Score);
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

    static Entitas.IMatcher<GameEntity> _matcherScore;

    public static Entitas.IMatcher<GameEntity> Score {
        get {
            if (_matcherScore == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Score);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherScore = matcher;
            }

            return _matcherScore;
        }
    }
}
