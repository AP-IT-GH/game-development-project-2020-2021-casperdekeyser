using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.LevelManagement.Screens
{
    public abstract class Screen : IGameScreen
    {
        public abstract int ScreenId { get; set; }

        // Game
        protected ContentManager _content;
        protected GraphicsDevice _graphics;
        protected SpriteBatch _spriteBatch;
        protected Game1 _game;

        // Map
        protected MapMaker mapMaker;

        // Collision
        protected CollisionManager collisionManager;
        protected List<BoxCollider> colliders;


        public Screen(Game1 game)
        {
            _game = game;
            _content = game.Content;
            _graphics = game.GraphicsDevice;

            Initialize();
            LoadContent();

        }

        protected virtual void Initialize()
        {
            // Map
            mapMaker = new MapMaker();
            mapMaker.CreateLevel(ScreenId);

            // Collision
            colliders = new List<BoxCollider>();
            foreach (IMapObject block in mapMaker.Blocks)
            {
                colliders.Add(block.Collider);
            }
            collisionManager = new CollisionManager(colliders);

        }

        protected virtual void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            // TODO: use this.Content to load your game content here

            foreach (IMapObject block in mapMaker.Blocks)
            {
                block.Spritesheet = _content.Load<Texture2D>(block.SpritesheetPath);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            // wait untill exit
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();

            mapMaker.DrawLevel(ScreenId, _spriteBatch);

            if (ScreenId == 3) collisionManager.DrawBlockColliders(_spriteBatch, _game.GraphicsDevice, Color.Green);
            if (ScreenId == 4) collisionManager.DrawBlockColliders(_spriteBatch, _game.GraphicsDevice, Color.Red);

            _spriteBatch.End();
        }


    }
}
