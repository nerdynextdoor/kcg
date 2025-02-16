﻿using System;
using KMath;
using Planet;
using UnityEngine;

namespace Action
{
    public class FireWeaponAction : ActionBase
    {
        ProjectileEntity ProjectileEntity;
        Vec2f StartPos;

        public FireWeaponAction(Contexts entitasContext, int actionID, int agentID) : base(entitasContext, actionID, agentID)
        {
        }

        public override void OnEnter(ref Planet.PlanetState planet)
        {
            const float speed = 20.0f;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float x = worldPosition.x;
            float y = worldPosition.y;

            // Start positiom
            StartPos = AgentEntity.physicsPosition2D.Value;
            StartPos.X += 0.3f;
            StartPos.Y += 0.5f;

            ProjectileEntity = planet.AddProjectile(StartPos, new Vec2f(x - StartPos.X, y - StartPos.Y).Normalized, Enums.ProjectileType.Bullet);
           /* ProjectileEntity = GameState.ProjectileSpawnerSystem.SpawnBullet(GameResources.OreIcon, 4, 4, StartPos, 
                new Vec2f(x - StartPos.X, y - StartPos.Y).Normalized * speed, Vec2f.Zero, Enums.ProjectileType.Bullet, Enums.ProjectileDrawType.Standard);*/
            ActionEntity.ReplaceActionExecution(this, Enums.ActionState.Running);
        }

        public override void OnUpdate(float deltaTime, ref Planet.PlanetState planet)
        {
            const float range = 10.0f;
            base.OnUpdate(deltaTime, ref planet);

            // Check if projectile has hit something and was destroyed.
            if (!ProjectileEntity.isEnabled)
            {
                ActionEntity.ReplaceActionExecution(this, Enums.ActionState.Success);
                return;
            }

            // Check if projectile is inside in weapon range.
            if ((ProjectileEntity.projectilePosition2D.Value - StartPos).Magnitude > range)
            {
                ActionEntity.ReplaceActionExecution(this, Enums.ActionState.Success);
            }

            // Check if projectile has hit a enemy.
            var entities = EntitasContext.agent.GetGroup(AgentMatcher.AllOf(AgentMatcher.AgentID));

            // Todo: Create a agent colision system?
            foreach (var entity in entities)
            {
                if (entity == AgentEntity)
                    continue;

                Vec2f entityPos = entity.physicsPosition2D.Value;
                Vec2f bulletPos = ProjectileEntity.projectilePosition2D.Value;
                var movable = entity.physicsMovable;

                Vec2f diff = bulletPos - entityPos;

                float Len = diff.Magnitude;
                diff.Y = 0;
                diff.Normalize();

                if (entity.hasAgentStats && Len <= 0.5f)
                {
                    Vector2 oppositeDirection = new Vector2(-diff.X, -diff.Y);
                    var stats = entity.agentStats;
                    float damage = 20.0f;
                    entity.ReplaceAgentStats(stats.Health - (int)damage, stats.Food, stats.Water, stats.Oxygen, 
                        stats.Fuel, stats.AttackCooldown);

                    // spawns a debug floating text for damage 
                    planet.AddFloatingText("" + damage, 0.5f, new Vec2f(oppositeDirection.x * 0.05f, oppositeDirection.y * 0.05f), new Vec2f(entityPos.X, entityPos.Y + 0.35f));
                    ActionEntity.ReplaceActionExecution(this, Enums.ActionState.Success);
                }
            }
        }

        public override void OnExit(ref PlanetState planet)
        {
            if (ProjectileEntity.isEnabled)
            {
                ProjectileEntity.Destroy();
            }
            base.OnExit(ref planet);
        }
    }

    // Factory Method
    public class FireWeaponActionCreator : ActionCreator
    {
        public override ActionBase CreateAction(Contexts entitasContext, int actionID, int agentID)
        {
            return new FireWeaponAction(entitasContext, actionID, agentID);
        }
    }
}

