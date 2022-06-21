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
    public ParticleContext particle { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game, input, particle }; } }

    public Contexts() {
        game = new GameContext();
        input = new InputContext();
        particle = new ParticleContext();

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

    public const string ActionID = "ActionID";
    public const string AgentAIController = "AgentAIController";
    public const string AgentID = "AgentID";
    public const string AIGoal = "AIGoal";
    public const string InventoryID = "InventoryID";
    public const string ItemAttachedInventory = "ItemAttachedInventory";
    public const string ItemAttributeAction = "ItemAttributeAction";
    public const string ItemAttributes = "ItemAttributes";
    public const string ItemIDID = "ItemIDID";
    public const string ItemIDItemType = "ItemIDItemType";
    public const string ProjectileID = "ProjectileID";
    public const string VehicleID = "VehicleID";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            ActionID,
            game.GetGroup(GameMatcher.ActionID),
            (e, c) => ((Action.IDComponent)c).ID));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            AgentAIController,
            game.GetGroup(GameMatcher.AgentAIController),
            (e, c) => ((Agent.AIController)c).AgentPlannerID));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            AgentID,
            game.GetGroup(GameMatcher.AgentID),
            (e, c) => ((Agent.IDComponent)c).ID));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            AIGoal,
            game.GetGroup(GameMatcher.AIGoal),
            (e, c) => ((AI.GoalComponent)c).GoalID));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            InventoryID,
            game.GetGroup(GameMatcher.InventoryID),
            (e, c) => ((Inventory.IDComponent)c).ID));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            ItemAttachedInventory,
            game.GetGroup(GameMatcher.ItemAttachedInventory),
            (e, c) => ((Item.AttachedInventoryComponent)c).InventoryID));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            ItemAttributeAction,
            game.GetGroup(GameMatcher.ItemAttributeAction),
            (e, c) => ((Item.Attribute.ActionComponent)c).ActionID));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, Enums.ItemType>(
            ItemAttributes,
            game.GetGroup(GameMatcher.ItemAttributes),
            (e, c) => ((Item.Attributes.Component)c).ItemType));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            ItemIDID,
            game.GetGroup(GameMatcher.ItemID),
            (e, c) => ((Item.IDComponent)c).ID));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, Enums.ItemType>(
            ItemIDItemType,
            game.GetGroup(GameMatcher.ItemID),
            (e, c) => ((Item.IDComponent)c).ItemType));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            ProjectileID,
            game.GetGroup(GameMatcher.ProjectileID),
            (e, c) => ((Projectile.IDComponent)c).ID));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            VehicleID,
            game.GetGroup(GameMatcher.VehicleID),
            (e, c) => ((Vehicle.IDComponent)c).ID));
    }
}

public static class ContextsExtensions {

    public static GameEntity GetEntityWithActionID(this GameContext context, int ID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ActionID)).GetEntity(ID);
    }

    public static GameEntity GetEntityWithAgentAIController(this GameContext context, int AgentPlannerID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.AgentAIController)).GetEntity(AgentPlannerID);
    }

    public static GameEntity GetEntityWithAgentID(this GameContext context, int ID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.AgentID)).GetEntity(ID);
    }

    public static GameEntity GetEntityWithAIGoal(this GameContext context, int GoalID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.AIGoal)).GetEntity(GoalID);
    }

    public static GameEntity GetEntityWithInventoryID(this GameContext context, int ID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.InventoryID)).GetEntity(ID);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithItemAttachedInventory(this GameContext context, int InventoryID) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ItemAttachedInventory)).GetEntities(InventoryID);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithItemAttributeAction(this GameContext context, int ActionID) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ItemAttributeAction)).GetEntities(ActionID);
    }

    public static GameEntity GetEntityWithItemAttributes(this GameContext context, Enums.ItemType ItemType) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, Enums.ItemType>)context.GetEntityIndex(Contexts.ItemAttributes)).GetEntity(ItemType);
    }

    public static GameEntity GetEntityWithItemIDID(this GameContext context, int ID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ItemIDID)).GetEntity(ID);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithItemIDItemType(this GameContext context, Enums.ItemType ItemType) {
        return ((Entitas.EntityIndex<GameEntity, Enums.ItemType>)context.GetEntityIndex(Contexts.ItemIDItemType)).GetEntities(ItemType);
    }

    public static GameEntity GetEntityWithProjectileID(this GameContext context, int ID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ProjectileID)).GetEntity(ID);
    }

    public static GameEntity GetEntityWithVehicleID(this GameContext context, int ID) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.VehicleID)).GetEntity(ID);
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
            CreateContextObserver(particle);
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
