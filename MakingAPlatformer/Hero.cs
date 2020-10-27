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
        private Animation animation;
        private int speed = 2;


        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 150, 150)));
            animation.AddFrame(new AnimationFrame(new Rectangle(150, 0, 150, 150)));
            animation.AddFrame(new AnimationFrame(new Rectangle(300, 0, 150, 150)));
            animation.AddFrame(new AnimationFrame(new Rectangle(450, 0, 150, 150)));
            animation.AddFrame(new AnimationFrame(new Rectangle(600, 0, 150, 150)));
            animation.AddFrame(new AnimationFrame(new Rectangle(750, 0, 150, 150)));
            animation.AddFrame(new AnimationFrame(new Rectangle(900, 0, 150, 150)));
            animation.AddFrame(new AnimationFrame(new Rectangle(1050, 0, 150, 150)));
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
                Direction = new Vector2(-speed, 0);
            
            if (state.IsKeyDown(Keys.Right))
                Direction = new Vector2(speed, 0);

            Position += Direction;
            animation.Update(gameTime);
        }

        public void Move()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animation.CurrentFrame.sourceRectangle, Color.White);

        }
    }
}
