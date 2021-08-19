﻿using MakingAPlatformer.Content;
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

        protected ContentLoader _contentLoader;

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

        public Level(Game1 game)
        {
            _graphics = game.GraphicsDevice;
            _content = game.Content;
            _game = game;

            _contentLoader = game.ContentLoader;

            Initialize();
            LoadContent();
        }

        protected virtual void Initialize()
        {
            // Hero
            heroPosition = new Vector2(50, 868 - 96);
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroPosition, heroAnimator, inputReader, animateCommand);

            // Map
            mapMaker = new MapMaker();
            mapMaker.CreateLevel(LevelId);

            // Collision
            collisionManager = new CollisionManager(mapMaker.Blocks, hero);

            // UI
            _healthManager = new HealthManager(3, hero, _game.ScreenManager);

        }

        protected virtual void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            // TODO: use this.Content to load your game content here
            _contentLoader.LoadContent(_content, hero, mapMaker, _healthManager);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (transitionZone.CheckCollision(hero)) _game.ScreenManager.ManageTransitions(LevelId);

            collisionManager.Execute();
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
