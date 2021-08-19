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
        protected ContentManager content;
        protected GraphicsDevice graphics;
        protected SpriteBatch spriteBatch;
        protected Game1 game;

        // Map
        protected MapMaker mapMaker;

        // Collision
        protected CollisionManager collisionManager;
        protected List<BoxCollider> colliders;

        // Timer
        private Timing.Timer _timer;

        public Screen(Game1 game)
        {
            this.game = game;
            content = game.Content;
            graphics = game.GraphicsDevice;

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
            spriteBatch = new SpriteBatch(graphics);

            // TODO: use this.Content to load your game content here
            game.ContentLoader.LoadContent(content, mapMaker);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (_timer.SecondsElapsed(Duration, gameTime)) game.Exit();
        }

        public virtual void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            mapMaker.DrawLevel(spriteBatch);
            collisionManager.DrawBlockColliders(spriteBatch, game.GraphicsDevice, DrawingColor); // fill out blocks

            spriteBatch.End();
        }
    }
}
