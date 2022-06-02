//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public GameContext game { get; set; }
    public InputContext input { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game, input }; } }

    public Contexts() {
        game = new GameContext();
        input = new InputContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string AgentID = "AgentID";
    public const string InventoryID = "InventoryID";
    public const string Item = "Item";
    public const string ItemAttachedInventory = "ItemAttachedInventory";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            AgentID,
            game.GetGroup(GameMatcher.AgentID),
            (e, c) => ((Agent.IDComponent)c).ID));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            InventoryID,
            game.GetGroup(GameMatcher.InventoryID),
            (e, c) => ((Inventory.IDComponent)c).InventoryID));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, Enums.ItemType>(
            Item,
            game.GetGroup(GameMatcher.Item),
            (e, c) => ((Item.Component)c).ItemType));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            ItemAttachedInventory,
            game.GetGroup(GameMatcher.ItemAttachedInventory),
            (e, c) => ((Item.AttachedInventoryComponent)c).InventoryID));
    }
}

public static class ContextsExtensions {

    public static GameEntity GetEntityWithAgentID(this GameContext context, int ID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.AgentID)).GetEntity(ID);
    }

    public static GameEntity GetEntityWithInventoryID(this GameContext context, int InventoryID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.InventoryID)).GetEntity(InventoryID);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithItem(this GameContext context, Enums.ItemType ItemType) {
        return ((Entitas.EntityIndex<GameEntity, Enums.ItemType>)context.GetEntityIndex(Contexts.Item)).GetEntities(ItemType);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithItemAttachedInventory(this GameContext context, int InventoryID) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ItemAttachedInventory)).GetEntities(InventoryID);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContextObservers() {
        try {
            CreateContextObserver(game);
            CreateContextObserver(input);
        } catch(System.Exception) {
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}
