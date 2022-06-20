﻿using UnityEngine;
using System.Collections.Generic;

using Enums;
using KMath;

namespace Item
{
    public class SpawnerSystem
    {
        public Contexts EntitasContext;

        private static int ItemID;

        public SpawnerSystem(Contexts entitasContext)
        {
            EntitasContext = entitasContext;
        }

        public GameEntity SpawnItem(ItemType itemType, Vec2f position)
        {
            var entityAttribute = EntitasContext.game.GetEntityWithItemAttributes(itemType);
            Vec2f size = entityAttribute.itemAttributeSize.Size;

            var entity = EntitasContext.game.CreateEntity();
            entity.AddItemID(ItemID, itemType);
            entity.AddPhysicsPosition2D(position, Vec2f.Zero);
            entity.AddPhysicsBox2DCollider(size, Vec2f.Zero);
            entity.AddPhysicsMovable(0f, Vec2f.Zero, Vec2f.Zero);

            ItemID++;
            return entity;
        }

        public GameEntity SpawnInventoryItem(ItemType itemType)
        {
            var entity = EntitasContext.game.CreateEntity();
            entity.AddItemID(ItemID, itemType);

            ItemID++;
            return entity;
        }
    }
}

