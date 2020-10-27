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

        private Texture2D heroTexture;
        private int speed = 2;

        public Animator Animator;

        public Hero()
        {
            Animator = new Animator();
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
                Direction = new Vector2(-speed, 0);
            
            if (state.IsKeyDown(Keys.Right))
                Direction = new Vector2(speed, 0);

            Position += Direction;
            Animator.Update(gameTime);
        }

        public void Move()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(heroTexture, Position, Animator.Animations[0].CurrentFrame.sourceRectangle, Color.White);
            spriteBatch.Draw(Animator.Animations[0].SpriteSheet, Position, Animator.Animations[0].CurrentFrame.sourceRectangle, Color.White);

        }
    }
}
