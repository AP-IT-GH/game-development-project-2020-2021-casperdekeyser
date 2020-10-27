using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Hero
    {
        Texture2D heroTexture;
        Animation animation;
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
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10), animation.CurrentFrame.sourceRectangle, Color.White);

        }
    }
}
