using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Hero
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction;
        public Animator Animator;

        private Texture2D heroTexture;
        private int speed = 2;
        private Animation currentAnimation;

        public Hero()
        {
            Animator = new Animator();
            currentAnimation = Animator.Animations[0];
        }

        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            Animator = new Animator();
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                Direction = new Vector2(-speed, 0);
                currentAnimation = Animator.Animations[1];

            }
            
            if (state.IsKeyDown(Keys.Right))
            {
                Direction = new Vector2(speed, 0);
                currentAnimation = Animator.Animations[0];
            }

            Position += Direction;
            Animator.Update(gameTime);
        }

        public void Move()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.SpriteSheet, Position, currentAnimation.CurrentFrame.sourceRectangle, Color.White);
        }
    }
}
