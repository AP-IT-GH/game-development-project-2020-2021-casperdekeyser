using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.UI
{
    public class Heart
    {
        public Vector2 Position { get; set; }
        public Texture2D Spritesheet { get; set; }
        public string SpritesheetPath { get; set; }

        private int _size = 32;


        public Heart(Vector2 position)
        {
            Position = position;
            SpritesheetPath = "UI/heart-pixel-art-32x32";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(0, 0, _size, _size), Color.White);
        }

    }
}
