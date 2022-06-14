using Enums;
using KMath;
using UnityEngine;

namespace Physics
{
    public class ProcessCollisionSystem
    {
        public void Update(Planet.TileMap tileMap)
        {
            float deltaTime = Time.deltaTime;
            var entitiesWithBox = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.PhysicsBox2DCollider, GameMatcher.PhysicsPosition2D));
            var entitiesWithCircle = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.PhysicsCircle2DCollider, GameMatcher.PhysicsPosition2D));

            foreach (var entity in entitiesWithCircle)
            {
                var pos = entity.physicsPosition2D;
                var radius = entity.physicsCircle2DCollider.Radius;
                var movable = entity.physicsMovable;

                var circle = Circle.Create(pos.PreviousValue, radius, entity.agentSprite2D.Size);

                var intersectionPoint = circle.GetTileIntersectionPoint(tileMap, pos.Value);

                if (intersectionPoint.IsCollided)
                {
                    if (intersectionPoint.Side is CircleQuarter.Right or CircleQuarter.Left)
                    {
                        entity.ReplacePhysicsPosition2D(new Vec2f(pos.PreviousValue.X, pos.Value.Y), pos.PreviousValue);
                        entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(0.0f, movable.Velocity.Y), new Vec2f(0.0f, movable.Acceleration.Y));
                    }
                    if (intersectionPoint.Side is CircleQuarter.Top or CircleQuarter.Bottom)
                    {
                        entity.ReplacePhysicsPosition2D(new Vec2f(pos.Value.X, pos.PreviousValue.Y), pos.PreviousValue);
                        entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(movable.Velocity.Y, 0.0f), new Vec2f(movable.Acceleration.X, 0.0f));
                    }
                    
                    if (intersectionPoint.Side is CircleQuarter.TopRight)
                    {
                        entity.ReplacePhysicsPosition2D(new Vec2f(pos.PreviousValue.X, pos.Value.Y), pos.PreviousValue);
                        entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(0.0f, movable.Velocity.Y), new Vec2f(0.0f, movable.Acceleration.Y));
                    }
                    if (intersectionPoint.Side is CircleQuarter.Top or CircleQuarter.Bottom)
                    {
                        entity.ReplacePhysicsPosition2D(new Vec2f(pos.Value.X, pos.PreviousValue.Y), pos.PreviousValue);
                        entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(movable.Velocity.Y, 0.0f), new Vec2f(movable.Acceleration.X, 0.0f));
                    }

                }
            }

            foreach (var entity in entitiesWithBox)
            {
                var pos = entity.physicsPosition2D;
                var entityBoxBorders = Box.Create(new Vec2f(pos.PreviousValue.X, pos.Value.Y) + entity.physicsBox2DCollider.Offset, entity.physicsBox2DCollider.Size);
                var movable = entity.physicsMovable;
                
                if (entityBoxBorders.IsCollidingBottom(tileMap, movable.Velocity))
                {
                    entity.ReplacePhysicsPosition2D(new Vec2f(pos.Value.X, pos.PreviousValue.Y), pos.PreviousValue);
                    entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(movable.Velocity.X, 0.0f), new Vec2f(movable.Acceleration.X, 0.0f));
                }
                else if (entityBoxBorders.IsCollidingTop(tileMap, movable.Velocity))
                {
                    entity.ReplacePhysicsPosition2D(new Vec2f(pos.Value.X, pos.PreviousValue.Y), pos.PreviousValue);
                    entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(movable.Velocity.X, 0.0f), new Vec2f(movable.Acceleration.X, 0.0f));
                }
                
                pos = entity.physicsPosition2D;
                entityBoxBorders = Box.Create(new Vec2f(pos.Value.X, pos.PreviousValue.Y) + entity.physicsBox2DCollider.Offset, entity.physicsBox2DCollider.Size);
                movable = entity.physicsMovable;
                
                if (entityBoxBorders.IsCollidingLeft(tileMap, movable.Velocity))
                {
                    entity.ReplacePhysicsPosition2D(new Vec2f(pos.PreviousValue.X, pos.Value.Y), pos.PreviousValue);
                    entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(0.0f, movable.Velocity.Y), new Vec2f(0.0f, movable.Acceleration.Y));
                }
                else if (entityBoxBorders.IsCollidingRight(tileMap, movable.Velocity))
                {
                    entity.ReplacePhysicsPosition2D(new Vec2f(pos.PreviousValue.X, pos.Value.Y), pos.PreviousValue);
                    entity.ReplacePhysicsMovable(movable.Speed, new Vec2f(0.0f, movable.Velocity.Y), new Vec2f(0.0f, movable.Acceleration.Y));
                }
            }
        }
    }
}
