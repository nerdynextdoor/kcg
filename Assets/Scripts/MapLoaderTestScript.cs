using System;
using UnityEngine;
using System.Collections.Generic;
using Physics;

#if UNITY_EDITOR
using KMath;
using UnityEditor;
#endif

namespace Planet.Unity
{
    //Note: TileMap should be mostly controlled by GameManager


    //Note(Mahdi): we are just testing and making sure everything is working
    // before we move things out of here
    // there will be things like rendering, collision, TileMap
    // that are not supposed to be here.

    class MapLoaderTestScript : MonoBehaviour
    {
        //public string TileMap = "Moonbunker/Moon Bunker.tmx";
        [SerializeField] Material Material;

        public static string BaseDir => Application.streamingAssetsPath;

        List<int> triangles = new();
        List<Vector2> uvs = new();
        List<Vector3> verticies = new();
        
        public Planet.TileMap TileMap;

        int SortingOrder = 0;

        int PlayerSpriteID;
        int PlayerSprite2ID;
        const float TileSize = 1.0f;

        readonly Vector2 MapOffset = new(-3.0f, 4.0f);

        static bool InitTiles;


        ECSInput.ProcessSystem InputProcessSystems;
        Agent.SpawnerSystem AgentSpawnerSystem;
        Physics.MovableSystem PhysicsMovableSystem;
        Agent.DrawSystem AgentDrawSystem;
        Physics.ProcessCollisionSystem AgentProcessCollisionSystem;

        public void Start()
        {
            if (!InitTiles)
            {
                InitializeSystems();
                CreateDefaultTiles();

                InitTiles = true;
            }
        }   

        void InitializeSystems()
        {
            int CharacterSpriteSheet = 
            Game.State.SpriteLoader.GetSpriteSheetID("Assets\\StreamingAssets\\Moonbunker\\Tilesets\\Sprites\\character\\character.png", 32, 48);

            int CharacterSpriteId = Game.State.SpriteAtlasManager.CopySpriteToAtlas(CharacterSpriteSheet, 0, 0, Enums.AtlasType.Agent);


            InputProcessSystems = new ECSInput.ProcessSystem();
            AgentSpawnerSystem = new Agent.SpawnerSystem();
            PhysicsMovableSystem = new Physics.MovableSystem();
            AgentDrawSystem = new Agent.DrawSystem();
            AgentProcessCollisionSystem = new Physics.ProcessCollisionSystem();

            AgentSpawnerSystem.SpawnPlayer(Material, CharacterSpriteId, 32, 48, new Vec2f(3.0f, 2.0f), 0, 0);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                int x = (int)worldPosition.x;
                int y = (int)worldPosition.y;
                
                var chunkIndex = TileMap.Chunks.GetChunkIndex(x, y);
                var tileIndex = Planet.Chunk.GetTileIndex(x, y);
                
                Debug.Log($"{x} {y} ChunkIndex: {chunkIndex} TileIndex: {tileIndex}");
            }
        
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                int x = (int)worldPosition.x;
                int y = (int)worldPosition.y;
                Debug.Log(x + " " + y);
                TileMap.RemoveTile(x, y, Enums.Tile.MapLayerType.Front);
                TileMap.Layers.BuildLayerTexture(TileMap, Enums.Tile.MapLayerType.Front);
                
            }

            foreach(var mr in GetComponentsInChildren<MeshRenderer>())
                if (Application.isPlaying)
                    Destroy(mr.gameObject);
                else
                    DestroyImmediate(mr.gameObject);

            InputProcessSystems.Update();
            PhysicsMovableSystem.Update();
            AgentProcessCollisionSystem.Update(TileMap);
            TileMap.Layers.DrawLayer(Enums.Tile.MapLayerType.Front, Instantiate(Material), transform, 10);
            TileMap.Layers.DrawLayer(Enums.Tile.MapLayerType.Ore, Instantiate(Material), transform, 11);
            AgentDrawSystem.Draw(Instantiate(Material), transform, 12);
        }


        public void CreateDefaultTiles()
        {
            int metalSlabsTileSheet = 
                        Game.State.SpriteLoader.GetSpriteSheetID("Assets\\StreamingAssets\\Moonbunker\\Tilesets\\Sprites\\Tiles_metal_slabs\\Tiles_metal_slabs.png", 16, 16);
            int stoneBulkheads = 
                        Game.State.SpriteLoader.GetSpriteSheetID("Assets\\StreamingAssets\\Moonbunker\\Tilesets\\Sprites\\tile_wallbase\\Tiles_stone_bulkheads.png", 16, 16);
            int tilesMoon = 
                        Game.State.SpriteLoader.GetSpriteSheetID("Assets\\StreamingAssets\\Moonbunker\\Tilesets\\Sprites\\tiles_moon\\Tiles_Moon.png", 16, 16);
            int oreTileSheet = 
            Game.State.SpriteLoader.GetSpriteSheetID("Assets\\StreamingAssets\\assets\\luis\\ores\\gem_hexagon_1.png", 16, 16);


            Game.State.TileCreationApi.CreateTile(8);
            Game.State.TileCreationApi.SetTileName("ore_1");
            Game.State.TileCreationApi.SetTileTexture16(oreTileSheet, 0, 0);
            Game.State.TileCreationApi.EndTile();

            Game.State.TileCreationApi.CreateTile(9);
            Game.State.TileCreationApi.SetTileName("glass");
            Game.State.TileCreationApi.SetTileSpriteSheet16(tilesMoon, 11, 10);
            Game.State.TileCreationApi.EndTile();



            // Generating the map
            Vec2i mapSize = new Vec2i(16, 16);

            TileMap = new Planet.TileMap(mapSize);

            for(int j = 0; j < mapSize.Y; j++)
            {
                for(int i = 0; i < mapSize.X; i++)
                {
                    Tile.Tile frontTile = Tile.Tile.EmptyTile;
                    Tile.Tile oreTile = Tile.Tile.EmptyTile;

                    frontTile.Type = 9;


                    if (i % 10 == 0)
                    {
                        oreTile.Type = 8;
                    }

                    if ((j > 1 && j < 6) || (j > (8 + i)))
                    {
                       frontTile.Type = -1; 
                       oreTile.Type = -1;
                    }

                    
                    TileMap.SetTile(i, j, frontTile, Enums.Tile.MapLayerType.Front);
                    TileMap.SetTile(i, j, oreTile, Enums.Tile.MapLayerType.Ore);
                }
            }

            TileMap.HeightMap.UpdateTopTilesMap(ref TileMap);
            TileMap.UpdateTileMapPositions(Enums.Tile.MapLayerType.Front);
            TileMap.UpdateTileMapPositions(Enums.Tile.MapLayerType.Ore);
            TileMap.Layers.BuildLayerTexture(TileMap, Enums.Tile.MapLayerType.Front);
            TileMap.Layers.BuildLayerTexture(TileMap, Enums.Tile.MapLayerType.Ore);
        }
    }
}
