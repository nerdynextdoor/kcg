using UnityEngine;
using System.Collections.Generic;
using Entitas;
using Enums.Tile;
using KMath;
using Enums;

namespace Planet.Unity
{
    class PlanetTest : MonoBehaviour
    {
        [SerializeField] Material Material;

        Planet.PlanetState Planet;
        Inventory.InventoryManager inventoryManager;
        Inventory.DrawSystem    inventoryDrawSystem;

        Contexts EntitasContext;


        Agent.AgentEntity Player;
        int PlayerID;

        int CharacterSpriteId;
        int inventoryID;
        int toolBarID;

        static bool Init = false;
  

        public void Start()
        {
            if (!Init)
            {
                Initialize();
                Init = true;
            }
        }


        public void Update()
        {
            Planet.TileMap TileMap = Planet.TileMap;
            Material material = Material;
            Vec2f playerPosition = Player.Entity.physicsPosition2D.Value;

            // Get Slot Entites
            IGroup<GameEntity> slotEntities =
            EntitasContext.game.GetGroup(GameMatcher.InventorySlots);
            int selectedIndex = 0;
            // Detect if spawner helded or not
            foreach (var slots in slotEntities)
            {
               selectedIndex = slots.inventorySlots.Selected; 
            }

           

            ItemType highlightItemType = Enums.ItemType.Error;
            var itemsInToolbar = EntitasContext.game.GetEntitiesWithItemAttachedInventory(toolBarID);
            foreach(var item in itemsInToolbar)
            {
                if (item.itemAttachedInventory.SlotNumber == selectedIndex)
                {
                    highlightItemType = item.itemID.ItemType;
                }
            }


            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (highlightItemType == Enums.ItemType.PlacementTool)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int x = (int)worldPosition.x;
                    int y = (int)worldPosition.y;
                    Planet.PlaceTile(x, y, (int)Tile.TileEnum.Moon, MapLayerType.Front);
                    //TileMap.BuildLayerTexture(MapLayerType.Front);
                }
                else if (highlightItemType == Enums.ItemType.PipePlacementTool)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int x = (int)worldPosition.x;
                    int y = (int)worldPosition.y;
                    Planet.PlaceTile(x, y, (int)Tile.TileEnum.Pipe, MapLayerType.Mid);
                    //TileMap.BuildLayerTexture(MapLayerType.Front);
                }
                else if (highlightItemType == Enums.ItemType.RemoveTileTool)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int x = (int)worldPosition.x;
                    int y = (int)worldPosition.y;
                    TileMap.RemoveTile(x, y, MapLayerType.Front);
                    TileMap.RemoveTile(x, y, MapLayerType.Ore);
                    //TileMap.BuildLayerTexture(MapLayerType.Front);
                    //TileMap.BuildLayerTexture(MapLayerType.Ore);
                }
                else if (highlightItemType == Enums.ItemType.SpawnEnemySlimeTool)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float x = worldPosition.x;
                    float y = worldPosition.y;
                    Planet.AddEnemy(Instantiate(Material), CharacterSpriteId, 32, 32, new Vec2f(x, y), 2);
                }
                else if (highlightItemType == Enums.ItemType.MiningLaserTool)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int fromX = (int)playerPosition.X;
                    int fromY = (int)playerPosition.Y;

                    int toX = (int)worldPosition.x;
                    int toY = (int)worldPosition.y;


                    Cell start = new Cell
                    {
                        x = (int)fromX,
                        y = (int)fromY
                    };

                    Cell end = new Cell
                    {
                        x = (int)toX,
                        y = (int)toY
                    };

                    // Log places drawed line go through
                    foreach (var cell in start.LineTo(end))
                    {
                        Debug.Log($"({cell.x},{cell.y})");

                        ref var tile = ref TileMap.GetTileRef(cell.x, cell.y, Enums.Tile.MapLayerType.Front);
                        if (tile.Type >= 0)
                        {
                            TileMap.RemoveTile(cell.x, cell.y, Enums.Tile.MapLayerType.Front);
                            TileMap.RemoveTile(cell.x, cell.y, Enums.Tile.MapLayerType.Ore);
                        }

                        Debug.DrawLine(new Vector3(playerPosition.X, playerPosition.Y, 0.0f),
                                     new Vector3(worldPosition.x, worldPosition.y, 0.0f), Color.red);
                    }

                    //TileMap.BuildLayerTexture(Enums.Tile.MapLayerType.Front);
                    //TileMap.BuildLayerTexture(Enums.Tile.MapLayerType.Ore);
                }
            }

                
            // unity rendering stuff
            // will be removed layer
            foreach(var mr in GetComponentsInChildren<MeshRenderer>())
            {
                if (Application.isPlaying)
                {
                    Destroy(mr.gameObject);
                }
                else
                {
                    DestroyImmediate(mr.gameObject);
                }
            }

            inventoryDrawSystem.Draw(Instantiate(Material), transform, 1000);
            Planet.Update(Time.deltaTime, Material, transform);

         //   Vector2 playerPosition = Player.Entity.physicsPosition2D.Value;

           // transform.position = new Vector3(playerPosition.x - 6.0f, playerPosition.y - 6.0f, -10.0f);
        }

        void DrawSpriteAtlas()
        {
            ref Sprites.SpriteAtlas atlas = ref GameState.SpriteAtlasManager.GetSpriteAtlas(Enums.AtlasType.Agent);
            Sprites.Sprite sprite = new Sprites.Sprite
            {
                Texture = atlas.Texture,
                TextureCoords = new Vector4(0, 0, 1, 1)
            };
            Utility.Render.DrawSprite(-3, -1, atlas.Width / 32.0f, atlas.Height / 32.0f, sprite, Instantiate(Material), transform);
        }

        // create the sprite atlas for testing purposes
        public void Initialize()
        {
            EntitasContext = Contexts.sharedInstance;

            inventoryManager = new Inventory.InventoryManager();
            inventoryDrawSystem = new Inventory.DrawSystem(EntitasContext);

            GameResources.Initialize();

            // Generating the map
            Vec2i mapSize = new Vec2i(32, 24);
            Planet = new Planet.PlanetState(mapSize, EntitasContext.game);
            GenerateMap();
            SpawnStuff();

            var inventoryAttacher = Inventory.InventoryAttacher.Instance;

            inventoryID = Player.Entity.agentInventory.InventoryID;
            toolBarID = Player.Entity.agentToolBar.ToolBarID;

            GameEntity gun = GameState.ItemSpawnSystem.SpawnInventoryItem(EntitasContext.game, Enums.ItemType.Gun);
            GameEntity ore = GameState.ItemSpawnSystem.SpawnInventoryItem(EntitasContext.game, Enums.ItemType.Ore);
            GameEntity placementTool = GameState.ItemSpawnSystem.SpawnInventoryItem(EntitasContext.game, Enums.ItemType.PlacementTool);
            GameEntity removeTileTool = GameState.ItemSpawnSystem.SpawnInventoryItem(EntitasContext.game, Enums.ItemType.RemoveTileTool);
            GameEntity spawnEnemySlimeTool = GameState.ItemSpawnSystem.SpawnInventoryItem(EntitasContext.game, Enums.ItemType.SpawnEnemySlimeTool);
            GameEntity miningLaserTool = GameState.ItemSpawnSystem.SpawnInventoryItem(EntitasContext.game, Enums.ItemType.MiningLaserTool);
            GameEntity pipePlacementTool = GameState.ItemSpawnSystem.SpawnInventoryItem(EntitasContext.game, Enums.ItemType.PipePlacementTool);


            inventoryManager.AddItem(placementTool, toolBarID);
            inventoryManager.AddItem(removeTileTool, toolBarID);
            inventoryManager.AddItem(spawnEnemySlimeTool, toolBarID);
            inventoryManager.AddItem(miningLaserTool, toolBarID);
            inventoryManager.AddItem(pipePlacementTool, toolBarID);
        }



        void GenerateOre()
        {
            Planet.TileMap TileMap = Planet.TileMap;

            Tile.Tile oreTile = Tile.Tile.EmptyTile;
            for(int j = 0; j < TileMap.MapSize.Y; j++)
            {
                for(int i = 0; i < TileMap.MapSize.X; i++)
                {
                    ref Tile.Tile tile = ref TileMap.GetTileRef(i, j, MapLayerType.Front);

                    if (tile.Type == 10 && (((int)KMath.Random.Mt19937.genrand_int32() % 30) == 0))
                    {
                        int type = ((int)KMath.Random.Mt19937.genrand_int32() % 6);
                        if (type == 0)
                        {
                            oreTile.Type = (int)Tile.TileEnum.Ore1;
                        }
                        else if (type == 1 || type == 2)
                        {
                            oreTile.Type = (int)Tile.TileEnum.Ore2;
                        }
                        else if (type == 3 || type == 4)
                        {
                            oreTile.Type = (int)Tile.TileEnum.Ore3;
                        }

                        TileMap.SetTile(i, j, oreTile, MapLayerType.Ore);
                    }
                }
            }
        }
        void GenerateMap()
        {
            KMath.Random.Mt19937.init_genrand((ulong)System.DateTime.Now.Ticks);
            Planet.TileMap TileMap = Planet.TileMap;

           Vec2i mapSize = TileMap.MapSize;

           for(int j = 0; j < mapSize.Y; j++)
            {
                for(int i = 0; i < mapSize.X; i++)
                {
                    Tile.Tile frontTile = Tile.Tile.EmptyTile;

                    if (i >= mapSize.X / 2)
                    {
                        if (j % 2 == 0 && i == mapSize.X / 2)
                        {
                            frontTile.Type = (int)Tile.TileEnum.Moon;
                        }
                        else
                        {
                            frontTile.Type = (int)Tile.TileEnum.Glass;
                        }
                    }
                    else
                    {
                        if (j % 3 == 0 && i == mapSize.X / 2 + 1)
                        {
                            frontTile.Type = (int)Tile.TileEnum.Glass;
                        }
                        else
                        {
                            frontTile.Type = (int)Tile.TileEnum.Moon;
                        }
                    }

                    
                    TileMap.SetTile(i, j, frontTile, MapLayerType.Front);
                }
            }

            for(int i = 0; i < TileMap.MapSize.X; i++)
            {
                for(int j = TileMap.MapSize.Y - 10; j < TileMap.MapSize.Y; j++)
                {
                    TileMap.SetTile(i, j, Tile.Tile.EmptyTile, MapLayerType.Front);
                }
            }

            int carveHeight = TileMap.MapSize.Y - 10;

            for(int i = 0; i < TileMap.MapSize.X; i++)
            {
                int move = ((int)KMath.Random.Mt19937.genrand_int32() % 3) - 1;
                if (((int)KMath.Random.Mt19937.genrand_int32() % 5) <= 3)
                {
                    move = 0;
                }
                carveHeight += move;
                if (carveHeight >= TileMap.MapSize.Y)
                {
                    carveHeight = TileMap.MapSize.Y - 1;
                }

                for(int j = carveHeight; j < TileMap.MapSize.Y && j < carveHeight + 4; j++)
                {
                    TileMap.SetTile(i, j, Tile.Tile.EmptyTile, MapLayerType.Front);
                }
            }

            carveHeight = 5;

            for(int i = TileMap.MapSize.X - 1; i >=0; i--)
            {
                int move = ((int)KMath.Random.Mt19937.genrand_int32() % 3) - 1;
                if (((int)KMath.Random.Mt19937.genrand_int32() % 10) <= 3)
                {
                    move = 1;
                }
                carveHeight += move;
                if (carveHeight >= TileMap.MapSize.Y)
                {
                    carveHeight = TileMap.MapSize.Y - 1;
                }

                for(int j = carveHeight; j < TileMap.MapSize.Y && j < carveHeight + 4; j++)
                {
                    TileMap.SetTile(i, j, Tile.Tile.EmptyTile, MapLayerType.Front);
                }
            }


            GenerateOre();

            TileMap.HeightMap.UpdateTopTilesMap(ref TileMap);

            TileMap.UpdateTileMapPositions(MapLayerType.Front);
            TileMap.UpdateTileMapPositions(MapLayerType.Ore);
            //TileMap.BuildLayerTexture(MapLayerType.Front);
            //TileMap.BuildLayerTexture(MapLayerType.Ore);
        
        }

        void SpawnStuff()
        {
            Planet.TileMap TileMap = Planet.TileMap;
            System.Random random = new System.Random((int)System.DateTime.Now.Ticks);

            float spawnHeight = TileMap.MapSize.Y + 2.0f;

            Player = Planet.AddPlayer(Instantiate(Material), CharacterSpriteId, 32, 48, 
                    new Vec2f(3.0f, spawnHeight), 0);
            PlayerID = Player.Entity.agentID.ID;

            Planet.AddAgent(Instantiate(Material), CharacterSpriteId, 32, 48, new Vec2f(6.0f, spawnHeight), 0);
            Planet.AddAgent(Instantiate(Material), CharacterSpriteId, 32, 48, new Vec2f(1.0f, spawnHeight), 0);

            for(int i = 0; i < TileMap.MapSize.X; i++)
            {
                if (random.Next() % 5 == 0)
                {
                    Planet.AddEnemy(Instantiate(Material), CharacterSpriteId, 32, 32, new Vec2f((float)i, spawnHeight), 2);    
                }
            }


            
            GameState.ItemSpawnSystem.SpawnItem(EntitasContext.game, Enums.ItemType.Gun, new Vec2f(6.0f, spawnHeight));
            GameState.ItemSpawnSystem.SpawnItem(EntitasContext.game, Enums.ItemType.Ore, new Vec2f(3.0f, spawnHeight));
        }
        
    }
}
