using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public abstract class Block : IMapObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Spritesheet{ get; set; }
        public string SpritesheetPath { get; set; }
        public BoxCollider Collider { get; set; }

        public virtual int RowOnMasterTileset { get; set; }

        protected int _size = 62;
        protected int _variation = 0;

        public Block(Vector2 position, int variation = 0)
        {
            Position = position;
            SpritesheetPath = "Map/master-tileset";
            Collider = new BoxCollider(Position, "Block-Collider", _size, _size);

            _variation = variation;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(_size * (_variation * 2), _size * RowOnMasterTileset, _size, _size), Color.White);
        }
    }
}
