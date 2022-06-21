//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int ActionAnimation = 0;
    public const int ActionBeginCoolDown = 1;
    public const int ActionCoolDown = 2;
    public const int ActionExecution = 3;
    public const int ActionGoap = 4;
    public const int ActionID = 5;
    public const int ActionMoveTo = 6;
    public const int ActionTime = 7;
    public const int AgentActionScheduler = 8;
    public const int AgentAIController = 9;
    public const int AgentEnemy = 10;
    public const int AgentID = 11;
    public const int AgentInventory = 12;
    public const int AgentPlayer = 13;
    public const int AgentPositionDiscrete2D = 14;
    public const int AgentSprite2D = 15;
    public const int AgentStats = 16;
    public const int AgentToolBar = 17;
    public const int AIGoal = 18;
    public const int AnimationState = 19;
    public const int ECSInput = 20;
    public const int ECSInputXY = 21;
    public const int FloatingTextID = 22;
    public const int FloatingTextMovable = 23;
    public const int FloatingTextState = 24;
    public const int InventoryDrawable = 25;
    public const int InventoryID = 26;
    public const int InventorySize = 27;
    public const int InventorySlots = 28;
    public const int InventoryToolBar = 29;
    public const int ItemAttachedInventory = 30;
    public const int ItemAttributeAction = 31;
    public const int ItemAttributeConsumable = 32;
    public const int ItemAttributeEquipament = 33;
    public const int ItemAttributeInventorySprite = 34;
    public const int ItemAttributePlaceable = 35;
    public const int ItemAttributeSize = 36;
    public const int ItemAttributeSprite = 37;
    public const int ItemAttributeStackable = 38;
    public const int ItemAttributes = 39;
    public const int ItemDrawPosition2D = 40;
    public const int ItemID = 41;
    public const int ItemLabel = 42;
    public const int ItemStack = 43;
    public const int ItemUnpickable = 44;
    public const int ItemUse = 45;
    public const int PhysicsBox2DCollider = 46;
    public const int PhysicsMovable = 47;
    public const int PhysicsPosition2D = 48;
    public const int PhysicsSphere2DCollider = 49;
    public const int ProjectileCollider = 50;
    public const int ProjectileID = 51;
    public const int ProjectilePhysicsState2D = 52;
    public const int ProjectileSprite2D = 53;
    public const int ProjectileType = 54;
    public const int VehicleID = 55;
    public const int VehiclePhysicsState2D = 56;
    public const int VehicleSprite2D = 57;

    public const int TotalComponents = 58;

    public static readonly string[] componentNames = {
        "ActionAnimation",
        "ActionBeginCoolDown",
        "ActionCoolDown",
        "ActionExecution",
        "ActionGoap",
        "ActionID",
        "ActionMoveTo",
        "ActionTime",
        "AgentActionScheduler",
        "AgentAIController",
        "AgentEnemy",
        "AgentID",
        "AgentInventory",
        "AgentPlayer",
        "AgentPositionDiscrete2D",
        "AgentSprite2D",
        "AgentStats",
        "AgentToolBar",
        "AIGoal",
        "AnimationState",
        "ECSInput",
        "ECSInputXY",
        "FloatingTextID",
        "FloatingTextMovable",
        "FloatingTextState",
        "InventoryDrawable",
        "InventoryID",
        "InventorySize",
        "InventorySlots",
        "InventoryToolBar",
        "ItemAttachedInventory",
        "ItemAttributeAction",
        "ItemAttributeConsumable",
        "ItemAttributeEquipament",
        "ItemAttributeInventorySprite",
        "ItemAttributePlaceable",
        "ItemAttributeSize",
        "ItemAttributeSprite",
        "ItemAttributeStackable",
        "ItemAttributes",
        "ItemDrawPosition2D",
        "ItemID",
        "ItemLabel",
        "ItemStack",
        "ItemUnpickable",
        "ItemUse",
        "PhysicsBox2DCollider",
        "PhysicsMovable",
        "PhysicsPosition2D",
        "PhysicsSphere2DCollider",
        "ProjectileCollider",
        "ProjectileID",
        "ProjectilePhysicsState2D",
        "ProjectileSprite2D",
        "ProjectileType",
        "VehicleID",
        "VehiclePhysicsState2D",
        "VehicleSprite2D"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Action.AnimationComponent),
        typeof(Action.BeginCoolDownComponent),
        typeof(Action.CoolDownComponent),
        typeof(Action.ExecutionComponent),
        typeof(Action.GoapComponent),
        typeof(Action.IDComponent),
        typeof(Action.MoveToComponent),
        typeof(Action.TimeComponent),
        typeof(Agent.ActionSchedulerComponent),
        typeof(Agent.AIController),
        typeof(Agent.EnemyComponent),
        typeof(Agent.IDComponent),
        typeof(Agent.InventoryComponent),
        typeof(Agent.PlayerComponent),
        typeof(Agent.PositionDiscrete2DComponent),
        typeof(Agent.Sprite2DComponent),
        typeof(Agent.StatsComponent),
        typeof(Agent.ToolBarComponent),
        typeof(AI.GoalComponent),
        typeof(Animation.StateComponent),
        typeof(ECSInput.Component),
        typeof(ECSInput.XYComponent),
        typeof(FloatingText.IDComponent),
        typeof(FloatingText.MovableComponent),
        typeof(FloatingText.StateComponent),
        typeof(Inventory.DrawableComponent),
        typeof(Inventory.IDComponent),
        typeof(Inventory.SizeComponent),
        typeof(Inventory.SlotsComponent),
        typeof(Inventory.ToolBarComponent),
        typeof(Item.AttachedInventoryComponent),
        typeof(Item.Attribute.ActionComponent),
        typeof(Item.Attribute.ConsumableComponent),
        typeof(Item.Attribute.EquipamentComponent),
        typeof(Item.Attribute.InventorySpriteComponent),
        typeof(Item.Attribute.PlaceableComponent),
        typeof(Item.Attribute.SizeComponent),
        typeof(Item.Attribute.SpriteComponent),
        typeof(Item.Attribute.StackableComponent),
        typeof(Item.Attributes.Component),
        typeof(Item.DrawPosition2DComponent),
        typeof(Item.IDComponent),
        typeof(Item.LabelComponent),
        typeof(Item.StackComponent),
        typeof(Item.Unpickable),
        typeof(Item.UseComponent),
        typeof(Physics.Box2DColliderComponent),
        typeof(Physics.MovableComponent),
        typeof(Physics.Position2DComponent),
        typeof(Physics.Sphere2DColliderComponent),
        typeof(Projectile.ColliderComponent),
        typeof(Projectile.IDComponent),
        typeof(Projectile.PhysicsState2DComponent),
        typeof(Projectile.Sprite2DComponent),
        typeof(Projectile.TypeComponent),
        typeof(Vehicle.IDComponent),
        typeof(Vehicle.PhysicsState2DComponent),
        typeof(Vehicle.Sprite2DComponent)
    };
}
