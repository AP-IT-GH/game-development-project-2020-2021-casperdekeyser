using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.LevelManagement
{
    public abstract class Level : IGameScreen
    {
        public abstract int LevelId { get; set; }

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
        protected EndingZone endzone;

        // Collision
        protected CollisionManager collisionManager;
        protected List<BoxCollider> colliders;

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
            heroPosition = new Vector2(50, 868 - 96);
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroPosition, heroAnimator, inputReader, animateCommand);

            // Map
            mapMaker = new MapMaker();
            mapMaker.CreateLevel(LevelId);

            // Collision
            colliders = new List<BoxCollider>();
            foreach (IMapObject block in mapMaker.Blocks)
            {
                colliders.Add(block.Collider);
            }
            collisionManager = new CollisionManager(colliders, hero);
        }

        protected virtual void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            // TODO: use this.Content to load your game content here

            foreach (Animation animation in hero.Animator.Animations)
            {
                animation.SpriteSheet = _content.Load<Texture2D>(animation.SpriteSheetPath);
            }

            foreach (IMapObject block in mapMaker.Blocks)
            {
                block.Spritesheet = _content.Load<Texture2D>(block.SpritesheetPath);
            }
        }
        public void Update(GameTime gameTime)
        {
            if (endzone.CheckEnding(hero)) _game.ScreenManager.ManageTransitions(LevelId);
            //if (LevelId == 1) if (endzone.CheckEnding(hero)) _game.ScreenManager.ChangeScreen(new SecondLevel(_game));
            //if (LevelId == 2) if (endzone.CheckEnding(hero)) _game.ScreenManager.ChangeScreen(new VictoryScreen(_game));

            collisionManager.Execute();
            hero.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            mapMaker.DrawLevel(LevelId, _spriteBatch);

            // DRAW COLLIDERS
            //collisionManager.DrawAllColliders(_spriteBatch, _game.GraphicsDevice, Color.Red, Color.Green);
            //endzone.Draw(_spriteBatch, _graphics);

            _spriteBatch.End();
        }

    }
}
