using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MakingAPlatformer.LevelManagement.Screens
{
    public abstract class Screen : IGameScreen
    {
        public abstract int ScreenId { get; set; }
        public abstract Color DrawingColor { get; set; }
        public int Duration { get; set; } = 5;
        public virtual Color BackgroundColor { get; set; } = Color.Beige;

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

        // Timer
        private Timing.Timer _timer;

        public Screen(Game1 game)
        {
            _game = game;
            _content = game.Content;
            _graphics = game.GraphicsDevice;

            _timer = new Timing.Timer();

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
            if (_timer.SecondsElapsed(Duration, gameTime)) _game.Exit();
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();

            mapMaker.DrawLevel(_spriteBatch);

            collisionManager.DrawBlockColliders(_spriteBatch, _game.GraphicsDevice, DrawingColor);

            _spriteBatch.End();
        }
    }
}
