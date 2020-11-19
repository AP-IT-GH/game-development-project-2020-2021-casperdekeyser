using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    class Block
    {
        public Vector2 Position { get; set; }
        public int Width = 100;
        public int Height = 100;
        public Texture2D Spritesheet;
        public string SpritesheetPath { get; set; }

        public Block()
        {
            Position = new Vector2(300, 250);
            SpritesheetPath = "Map/master-tileset";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(0, 0, Width, Height), Color.Black);
        }
    }
}
