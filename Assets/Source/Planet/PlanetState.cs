 using Agent;
using Enums.Tile;
using Vehicle;
using Projectile;
using FloatingText;
using Particle;
using Enums;
using Item;
using KMath;
using UnityEngine;

namespace Planet
{
    public struct PlanetState
    {
        public int Index;
        public TimeState TimeState;

        public PlanetTileMap.TileMap TileMap;
        public AgentList AgentList;
        public VehicleList VehicleList;
        public ProjectileList ProjectileList;
        public FloatingTextList FloatingTextList;
        public ParticleEmitterList ParticleEmitterList;
        public ParticleList ParticleList;
        public ItemParticleList ItemParticleList;


        public GameContext GameContext;
        public ParticleContext ParticleContext;


        public PlanetState(Vec2i mapSize, GameContext gameContext, ParticleContext particleContext) : this()
        {
            TileMap = new PlanetTileMap.TileMap(mapSize);
            AgentList = new AgentList();
            VehicleList = new VehicleList();
            ProjectileList = new ProjectileList();
            FloatingTextList = new FloatingTextList();
            ParticleEmitterList = new ParticleEmitterList();
            ParticleList = new ParticleList();
            ItemParticleList = new ItemParticleList();

            GameContext = gameContext;
            ParticleContext = particleContext;
        }


        // Note(Mahdi): Deprecated will be removed soon
        public AgentEntity AddPlayer(int spriteId,
                                int width, int height, Vec2f position, int startingAnimation, int health, int food, int water, 
                                int oxygen, int fuel)
        {
            Utils.Assert(AgentList.Size < PlanetEntityLimits.AgentLimit);

            ref AgentEntity newEntity = ref AgentList.Add();
            GameEntity entity = GameState.AgentSpawnerSystem.SpawnPlayer(spriteId, width, height, position, newEntity.AgentId,
                    startingAnimation, health, food, water, oxygen, fuel, 0.2f);
            newEntity.Entity = entity;

            return newEntity;
        }

        public AgentEntity AddPlayer(Vec2f position)
        {
            Utils.Assert(AgentList.Size < PlanetEntityLimits.AgentLimit);

            ref AgentEntity newEntity = ref AgentList.Add();
            GameEntity entity = GameState.AgentSpawnerSystem.Spawn(position,
                    newEntity.AgentId,
                    Agent.AgentType.Player);
            newEntity.Entity = entity;

            return newEntity;
        }

        // Note(Mahdi): Deprecated will be removed soon
        public AgentEntity AddAgent(int spriteId, int width,
                     int height, Vec2f position, int startingAnimation)
        {
            Utils.Assert(AgentList.Size < PlanetEntityLimits.AgentLimit);

            ref AgentEntity newEntity = ref AgentList.Add();
            GameEntity entity = GameState.AgentSpawnerSystem.SpawnAgent(spriteId, width, height, position,
                                                                    newEntity.AgentId, startingAnimation);
            newEntity.Entity = entity;


            return newEntity;
        }

        public AgentEntity AddAgent(Vec2f position)
        {
            Utils.Assert(AgentList.Size < PlanetEntityLimits.AgentLimit);

            ref AgentEntity newEntity = ref AgentList.Add();
            GameEntity entity = GameState.AgentSpawnerSystem.Spawn(position,
                    newEntity.AgentId,
                    Agent.AgentType.Agent);
            newEntity.Entity = entity;

            return newEntity;
        }

        // Note(Mahdi): Deprecated will be removed soon
        public AgentEntity AddEnemy(int spriteId,
                        int width, int height, Vec2f position, int startingAnimation)
        {
            Utils.Assert(AgentList.Size < PlanetEntityLimits.AgentLimit);

            ref AgentEntity newEntity = ref AgentList.Add();
            GameEntity entity = GameState.AgentSpawnerSystem.SpawnEnemy(spriteId, width, height, position,
            newEntity.AgentId, startingAnimation);

            newEntity.Entity = entity;


            return newEntity;
        }

        public AgentEntity AddEnemy(Vec2f position)
        {
            Utils.Assert(AgentList.Size < PlanetEntityLimits.AgentLimit);

            ref AgentEntity newEntity = ref AgentList.Add();
            GameEntity entity = GameState.AgentSpawnerSystem.Spawn(position,
                    newEntity.AgentId,
                    Agent.AgentType.Enemy);
            newEntity.Entity = entity;

            return newEntity;
        }

        public void RemoveAgent(int agentId)
        {
            ref AgentEntity entity = ref AgentList.Get(agentId);
            Utils.Assert(entity.IsInitialized);
            entity.Entity.Destroy();
            AgentList.Remove(entity.AgentId);
        }

        public FloatingTextEntity AddFloatingText(string text, float timeToLive, Vec2f velocity, Vec2f position)
        {
            ref FloatingTextEntity newEntity = ref FloatingTextList.Add();
            GameEntity entity = GameState.FloatingTextSpawnerSystem.SpawnFloatingText(GameContext, text, timeToLive, velocity, position,
                         newEntity.FloatingTextId);

            newEntity.Entity = entity;

            return newEntity;
        }

        public void RemoveFloatingText(int floatingTextId)
        {
            ref FloatingTextEntity entity = ref FloatingTextList.Get(floatingTextId);
            Utils.Assert(entity.IsInitialized);
            entity.Entity.Destroy();
            FloatingTextList.Remove(entity);
        }

        public ParticleEmitterEntity AddParticleEmitter(Vec2f position, Particle.ParticleEmitterType type)
        {
            ref ParticleEmitterEntity newEntity = ref ParticleEmitterList.Add();
            ParticleEntity entity = GameState.ParticleEmitterSpawnerSystem.Spawn(ParticleContext, type, position, 
                        newEntity.ParticleEmitterId);
            newEntity.Entity = entity;


            return newEntity;
        }

        public void RemoveParticleEmitter(int particleEmitterId)
        {
            ref ParticleEmitterEntity entity = ref ParticleEmitterList.Get(particleEmitterId);
            Utils.Assert(entity.IsInitialized);
            entity.Entity.Destroy();
            ParticleEmitterList.Remove(entity.ParticleEmitterId);
        }


        public ParticlesEntity AddParticle(Vec2f position, Vec2f velocity, Particle.ParticleType type)
        {
            Utils.Assert(ParticleList.Size < PlanetEntityLimits.ParticleLimit);

            ref ParticlesEntity newEntity = ref ParticleList.Add();
            ParticleEntity entity = GameState.ParticleSpawnerSystem.Spawn(ParticleContext, type, position, 
                        velocity, newEntity.ParticleId);
            newEntity.Entity = entity;


            return newEntity;
        }

        public void RemoveParticle(int particleId)
        {
            ref ParticlesEntity entity = ref ParticleList.Get(particleId);
            entity.Entity.Destroy();
            ParticleList.Remove(entity.ParticleId);
        }

        public ProjectileEntity AddProjectile(Vec2f position, Vec2f direction, Enums.ProjectileType projectileType)
        {
            Utils.Assert(ProjectileList.Size < PlanetEntityLimits.ProjectileLimit);

            ref ProjectileEntity newEntity = ref ProjectileList.Add();
            GameEntity entity = GameState.ProjectileSpawnerSystem.Spawn(GameContext,
                         position, direction, projectileType, newEntity.ProjectileId);
            newEntity.Entity = entity;

            return newEntity;
        }

        public void RemoveProjectile(int projectileId)
        {
            ref ProjectileEntity entity = ref ProjectileList.Get(projectileId);
            Utils.Assert(entity.IsInitialized);
            entity.Entity.Destroy();
            ProjectileList.Remove(entity.ProjectileId);
        }

        public VehicleEntity AddVehicle(UnityEngine.Material material, Vector2 position)
        {
            Utils.Assert(VehicleList.Size < PlanetEntityLimits.VehicleLimit);

            return new VehicleEntity();
        }

        public void RemoveVehicle(int vehicleId)
        {
            VehicleList.Remove(vehicleId);
        }

        public ItemParticleEntity AddItemParticle(Vec2f position, ItemType itemType)
        {
            Utils.Assert(ItemParticleList.Size < PlanetEntityLimits.ItemParticlesLimit);

            ref ItemParticleEntity newEntity = ref ItemParticleList.Add();
            GameEntity entity = GameState.ItemSpawnSystem.SpawnItem(Contexts.sharedInstance, itemType, position);
            newEntity.Entity = entity;

            return newEntity;
        }

        public void RemoveItemParticle(int itemParticleId)
        {
            //TODO: implement this
        }



        // updates the entities, must call the systems and so on ..
        public void Update(float deltaTime, Material material, Transform transform)
        {
            float targetFps = 30.0f;
            float frameTime = 1.0f / targetFps;

            TimeState.Deficit += deltaTime;

            while (TimeState.Deficit >= frameTime)
            {
                TimeState.Deficit -= frameTime;
                // do a server/client tick right here
                {
                    TimeState.TickTime++;





                    for (int index = 0; index < ProjectileList.Capacity; index++)
                    {
                        ref ProjectileEntity projectile = ref ProjectileList.List[index];
                        if (projectile.IsInitialized)
                        {
                            //var position = projectile.Entity.projectilePhysicsState2D;
                        }
                    }


                }

            }

            // check if the sprite atlas textures needs to be updated
            for(int type = 0; type < GameState.SpriteAtlasManager.Length; type++)
            {
                GameState.SpriteAtlasManager.UpdateAtlasTexture(type);
            }

            // check if the tile sprite atlas textures needs to be updated
            for(int type = 0; type < GameState.TileSpriteAtlasManager.Length; type++)
            {
                GameState.TileSpriteAtlasManager.UpdateAtlasTexture(type);
            }

            // calling all the systems we have

            GameState.InputProcessSystem.Update();
            GameState.PhysicsMovableSystem.Update();
            GameState.PhysicsProcessCollisionSystem.Update(ref TileMap);
            GameState.EnemyAiSystem.Update(this);
            GameState.FloatingTextUpdateSystem.Update(this, frameTime);
            GameState.AnimationUpdateSystem.Update(frameTime);
            GameState.ItemPickUpSystem.Update();
            GameState.ActionSchedulerSystem.Update(frameTime, ref this);
            GameState.ParticleEmitterUpdateSystem.Update(this);
            GameState.ParticleUpdateSystem.Update(this, ParticleContext);
            GameState.ProjectileMovementSystem.Update();
            GameState.ProjectileCollisionSystem.UpdateEx(ref this);

            TileMap.DrawLayer(MapLayerType.Mid, Object.Instantiate(material), transform, 9);
            TileMap.DrawLayer(MapLayerType.Front, Object.Instantiate(material), transform, 10);
            GameState.AgentDrawSystem.Draw(Object.Instantiate(material), transform, 12);
            GameState.ItemDrawSystem.Draw(Contexts.sharedInstance, Material.Instantiate(material), transform, 13);
            GameState.ProjectileDrawSystem.Draw(Material.Instantiate(material), transform, 20);
            GameState.FloatingTextDrawSystem.Draw(transform, 10000);
            GameState.ParticleDrawSystem.Draw(ParticleContext, Material.Instantiate(material), transform, 50);
            #region Gui drawing systems
            //GameState.InventoryDrawSystem.Draw(material, transform, 1000);
            #endregion
        }
    }
}
