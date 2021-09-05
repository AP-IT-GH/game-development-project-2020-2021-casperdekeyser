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
        protected ContentManager content;
        protected GraphicsDevice graphics;
        protected SpriteBatch spriteBatch;
        protected Game1 game;

        // Hero
        protected ICharacter hero;
        protected Vector2 heroStartPosition = new Vector2(50, 868 - 96);
        protected IAnimator heroAnimator;
        protected IInputReader inputReader;
        protected IAnimateCommand animateCommand;

        // Map
        protected IBlockCreator blockGenerator;
        protected ILevelCreator mapMaker;
        protected ITransition transitionZone;

        // Collision
        protected ICollisionManager collisionManager;

        // UI
        protected IHealthManager healthManager;

        private int _amountOfLives = 3;


        public Level(Game1 game)
        {
            graphics = game.GraphicsDevice;
            content = game.Content;
            this.game = game;

            Initialize();
            LoadContent();
        }

        protected virtual void Initialize()
        {
            // Hero
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroStartPosition, heroAnimator, inputReader, animateCommand);

            // Map
            blockGenerator = new BlockGenerator();
            mapMaker = new MapMaker(blockGenerator);
            mapMaker.CreateLevel(LevelId);

            // UI
            healthManager = new HealthManager(_amountOfLives, hero, heroStartPosition, game.ScreenManager);

            // Collision
            collisionManager = new CollisionManager(mapMaker.Blocks, hero);
        }

        protected virtual void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics);
            game.ContentLoader.LoadContent(content, mapMaker, hero, healthManager);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (transitionZone.CheckCollision(hero)) game.ScreenManager.ManageTransitions(LevelId);
            collisionManager.CheckCollisions(healthManager);
            hero.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            hero.Draw(spriteBatch);
            healthManager.Draw(spriteBatch);
            mapMaker.DrawLevel(spriteBatch);

            // DRAW COLLIDERS
            //collisionManager.DrawAllColliders(spriteBatch, graphics, Color.Red, Color.Green);
            //transitionZone.Draw(spriteBatch, graphics, Color.Fuchsia);

            spriteBatch.End();
        }
    }
}
