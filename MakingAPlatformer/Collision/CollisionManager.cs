using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MakingAPlatformer
{
    public class CollisionManager
    {
        public static bool HorizontalColliding;
        public static bool VerticalColliding;

        public List<BoxCollider> Colliders;
        public IGameObject Hero;
        
        private int amountOfCollisions;

        public CollisionManager(List<IMapObject> blocks, IGameObject hero)
        {
            Colliders = new List<BoxCollider>();
            Hero = hero;

            AddColliders(blocks);
        }

        private void AddColliders(List<IMapObject> blocks)
        {
            foreach (IMapObject block in blocks)
            {
                Colliders.Add(block.Collider);
            }
        }

        public CollisionManager(List<BoxCollider> collliders)
        {
            Colliders = collliders;
        }

        public void Execute()
        {
            SyncColliders();
            HorizontalColliding = FutureCollisionX();
            VerticalColliding = FutureCollisionY();
            //Debug.WriteLine($"Position HeroCollider: {Hero.Collider.Position.X} / {Hero.Collider.Position.Y} ");
            //Debug.WriteLine($"Position Hero: {Hero.Position.X} / {Hero.Position.Y} ");

        }

        private void BasicCollision()
        {
            foreach (var collider in Colliders)
            {
                if (CheckCollision(Hero.Collider.Rectangle, collider.Rectangle))
                {
                    amountOfCollisions++;
                    Debug.WriteLine($"COLLISION {amountOfCollisions} with {collider.Name} on {DateTime.Now}");
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
                    amountOfCollisions++;
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
                    amountOfCollisions++;
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

        private void SyncColliders()
        {
            Hero.Collider.Update();
            foreach (var collider in Colliders)
            {
                collider.Update();
            }
        }


        public static BoxCollider UpdateCollider(Vector2 Position, BoxCollider Collider)
        {
            Collider.Rectangle.X = (int)Position.X;
            Collider.Rectangle.Y = (int)Position.Y;
            return Collider;
        }

        public static BoxCollider UpdateCollider(Vector2 Position, BoxCollider Collider, int Xoffset, int Yoffset)
        {
            Collider.Rectangle.X = (int)Position.X + Xoffset;
            Collider.Rectangle.Y = (int)Position.Y + Yoffset;
            return Collider;
        }

        public static Vector2 OffsetCollider(Vector2 currentPos, int horizontalOffset, int verticalOffset)
        {
            return new Vector2(currentPos.X+horizontalOffset, currentPos.Y+verticalOffset);
        }

        public bool ExternalCheck(Rectangle r1, Rectangle r2)
        {
            return true;
        }

    }
}
