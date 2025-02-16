//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity {

    public Action.IDComponent actionID { get { return (Action.IDComponent)GetComponent(ActionComponentsLookup.ActionID); } }
    public bool hasActionID { get { return HasComponent(ActionComponentsLookup.ActionID); } }

    public void AddActionID(int newID, int newTypeID) {
        var index = ActionComponentsLookup.ActionID;
        var component = (Action.IDComponent)CreateComponent(index, typeof(Action.IDComponent));
        component.ID = newID;
        component.TypeID = newTypeID;
        AddComponent(index, component);
    }

    public void ReplaceActionID(int newID, int newTypeID) {
        var index = ActionComponentsLookup.ActionID;
        var component = (Action.IDComponent)CreateComponent(index, typeof(Action.IDComponent));
        component.ID = newID;
        component.TypeID = newTypeID;
        ReplaceComponent(index, component);
    }

    public void RemoveActionID() {
        RemoveComponent(ActionComponentsLookup.ActionID);
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
public sealed partial class ActionMatcher {

    static Entitas.IMatcher<ActionEntity> _matcherActionID;

    public static Entitas.IMatcher<ActionEntity> ActionID {
        get {
            if (_matcherActionID == null) {
                var matcher = (Entitas.Matcher<ActionEntity>)Entitas.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.ActionID);
                matcher.componentNames = ActionComponentsLookup.componentNames;
                _matcherActionID = matcher;
            }

            return _matcherActionID;
        }
    }
}
