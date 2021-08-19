using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using MakingAPlatformer.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.LevelManagement
{
    public abstract class Level : IGameScreen
    {
        public abstract int LevelId { get; set; }
        public virtual Color BackgroundColor { get; set; } = Color.CornflowerBlue;

        // Game
        protected ContentManager _content;
        protected GraphicsDevice _graphics;
        protected SpriteBatch _spriteBatch;
        protected Game1 _game;

        // Hero
        protected IGameObject hero;
        protected Vector2 heroPosition;
        protected HeroAnimator heroAnimator;
        protected IInputReader inputReader;
        protected AnimateCommand animateCommand;

        // Map
        protected MapMaker mapMaker;
        protected Transition transitionZone;

        // Collision
        protected CollisionManager collisionManager;
        protected List<BoxCollider> colliders;

        // UI
        protected HealthManager _healthManager;
        protected Vector2 startPosition = new Vector2(50, 868 - 96);

        private int amountOfLives = 3;


        public Level(Game1 game)
        {
            _graphics = game.GraphicsDevice;
            _content = game.Content;
            _game = game;

            Initialize();
            LoadContent();
        }

        protected virtual void Initialize()
        {
            // Hero
            heroPosition = startPosition;
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroPosition, heroAnimator, inputReader, animateCommand);

            // Map
            mapMaker = new MapMaker();
            mapMaker.CreateLevel(LevelId);

            // UI
            _healthManager = new HealthManager(amountOfLives, hero, startPosition, _game.ScreenManager);

            // Collision
            collisionManager = new CollisionManager(mapMaker.Blocks, hero);

        }

        protected virtual void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            // TODO: use this.Content to load your game content here
            _game.ContentLoader.LoadContent(_content, mapMaker, hero, _healthManager);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (transitionZone.CheckCollision(hero)) _game.ScreenManager.ManageTransitions(LevelId);

            collisionManager.CheckCollisions(_healthManager);
            hero.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            _healthManager.Draw(_spriteBatch);

            mapMaker.DrawLevel(_spriteBatch);

            // DRAW COLLIDERS
            //collisionManager.DrawAllColliders(_spriteBatch, _game.GraphicsDevice, Color.Red, Color.Green);
            transitionZone.Draw(_spriteBatch, _graphics, Color.Fuchsia);

            _spriteBatch.End();
        }
    }
}
