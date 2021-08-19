using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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
            collisionManager = new CollisionManager(mapMaker.Blocks);

        }

        protected virtual void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            // TODO: use this.Content to load your game content here
            _game.ContentLoader.LoadContent(_content, mapMaker);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (_timer.SecondsElapsed(Duration, gameTime)) _game.Exit();
        }

        public virtual void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            mapMaker.DrawLevel(_spriteBatch);

            collisionManager.DrawBlockColliders(_spriteBatch, _game.GraphicsDevice, DrawingColor);

            _spriteBatch.End();
        }
    }
}
