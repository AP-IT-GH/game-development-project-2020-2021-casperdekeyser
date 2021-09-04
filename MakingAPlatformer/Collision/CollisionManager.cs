using MakingAPlatformer.Map.Blocks;
using MakingAPlatformer.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MakingAPlatformer
{
    public class CollisionManager
    {
        public static bool HorizontalColliding { get; set; }
        public static bool VerticalColliding { get; set; }
        public List<BoxCollider> Colliders { get; set; } = new List<BoxCollider>();
        public List<IMapObject> Blocks { get; set; } = new List<IMapObject>();
        public IGameObject Hero { get; set; }
        
        private int _amountOfCollisions;

        public CollisionManager(List<IMapObject> blocks, IGameObject hero)
        {
            Hero = hero;
            Blocks = blocks;
            AddColliders(blocks);
        }

        public CollisionManager(List<IMapObject> blocks)
        {
            AddColliders(blocks);
        }

        public void CheckCollisions(HealthManager healthManager)
        {
            SyncColliders();
            HorizontalColliding = FutureCollisionX();
            VerticalColliding = FutureCollisionY();
            //Debug.WriteLine($"Position HeroCollider: {Hero.Collider.Position.X} / {Hero.Collider.Position.Y} ");
            //Debug.WriteLine($"Position Hero: {Hero.Position.X} / {Hero.Position.Y} ");

            foreach (IMapObject block in Blocks)
            {
                if (block is Trap)
                {
                    Trap temp = block as Trap;
                    temp.CheckCollision(Hero, healthManager);
                }
            }
        }

        public void DrawAllColliders(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color heroColor, Color blockColor)
        {
            DrawHeroCollider(spriteBatch, graphicsDevice, heroColor);
            DrawBlockColliders(spriteBatch, graphicsDevice, blockColor);
        }

        public void DrawBlockColliders(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color blockColor)
        {
            foreach (var collider in Colliders)
            {
                collider.Draw(spriteBatch, graphicsDevice, blockColor);
            }
        }

        public void DrawHeroCollider(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color heroColor)
        {
            Hero.Collider.Draw(spriteBatch, graphicsDevice, heroColor);
        }

        public static BoxCollider UpdateCollider(Vector2 position, BoxCollider collider)
        {
            collider.Rectangle = new Rectangle((int)position.X, (int)position.Y, collider.Width, collider.Height );
            return collider;
        }

        public static BoxCollider UpdateCollider(Vector2 position, BoxCollider collider, int xOffset, int yOffset)
        {
            collider.Rectangle = new Rectangle((int)position.X + xOffset, (int)position.Y + yOffset, collider.Width, collider.Height);
            return collider;
        }

        public static Vector2 OffsetCollider(Vector2 currentPos, int xOffset, int yOffset)
        {
            return new Vector2(currentPos.X + xOffset, currentPos.Y + yOffset);
        }

        private void AddColliders(List<IMapObject> blocks)
        {
            foreach (IMapObject block in blocks)
            {
                Colliders.Add(block.Collider);
            }
        }

        private void SyncColliders()
        {
            Hero.Collider.Update();
            foreach (var collider in Colliders)
            {
                collider.Update();
            }
        }

        private void BasicCollision()
        {
            foreach (var collider in Colliders)
            {
                if (CheckCollision(Hero.Collider.Rectangle, collider.Rectangle))
                {
                    _amountOfCollisions++;
                    Debug.WriteLine($"COLLISION {_amountOfCollisions} with {collider.Name} on {DateTime.Now}");
                }
            }
        }

        private bool FutureCollisionX()
        {
            Vector2 futurePosition = new Vector2(Hero.Collider.Position.X + Hero.Direction.X, Hero.Collider.Position.Y + Hero.Direction.Y);
            Rectangle futureRectangle = new Rectangle((int)futurePosition.X, (int)futurePosition.Y, Hero.Collider.Width, Hero.Collider.Height);

            foreach (var collider in Colliders)
            {
                if (CheckCollision(futureRectangle, collider.Rectangle))
                {
                    _amountOfCollisions++;
                    //Debug.WriteLine($"COLLISION {amountOfCollisions} with {collider.Name} on {DateTime.Now}");
                    return true;
                }
            }
            return false;
        }

        private bool FutureCollisionY()
        {
            Vector2 futurePosition = new Vector2(Hero.Collider.Position.X + Hero.Direction.X, Hero.Collider.Position.Y + Hero.Direction.Y);
            Rectangle futureRectangle = new Rectangle((int)futurePosition.X, (int)futurePosition.Y + 1, Hero.Collider.Width, Hero.Collider.Height);

            foreach (var collider in Colliders)
            {
                if (CheckCollision(futureRectangle, collider.Rectangle))
                {
                    _amountOfCollisions++;
                    //Debug.WriteLine($"COLLISION {amountOfCollisions} with {collider.Name} on {DateTime.Now}");
                    return true;
                }
            }
            return false;
        }

        private bool CheckCollision(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
                return true;
            return false;
        }
    }
}
