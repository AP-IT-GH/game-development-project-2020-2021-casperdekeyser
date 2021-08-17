using MakingAPlatformer.LevelManagement;
using MakingAPlatformer.LevelManagement.Levels;
using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MakingAPlatformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Level _currentLevel;
        private Level _nextLevel;

        //// Hero
        //IGameObject hero;
        //Vector2 heroPosition;
        //HeroAnimator heroAnimator;
        //IInputReader inputReader;
        //AnimateCommand animateCommand;

        //// Map
        //MapMaker mapMaker;
        //EndingZone endzone;

        //// Collision
        //CollisionManager collisionManager;
        //List<BoxCollider> colliders;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Screen

            _graphics.PreferredBackBufferWidth = 1550;
            _graphics.PreferredBackBufferHeight = 930;
            _graphics.ApplyChanges();


            //// Objects
            //// Hero
            //heroPosition = new Vector2(50, 868-96);
            //heroAnimator = new HeroAnimator();
            //inputReader = new KeyboardReader();
            //animateCommand = new AnimateCommand();
            //hero = new Hero(heroPosition, heroAnimator, inputReader, animateCommand);

            //// Map
            //mapMaker = new MapMaker();
            //mapMaker.CreateWorld();

            //endzone = new EndingZone(new Vector2(1500, 0), "testendingzone", 62, 62);

            //// Collision
            //colliders = new List<BoxCollider>();
            //foreach (IMapObject block in mapMaker.Blocks)
            //{
            //    colliders.Add(block.Collider);
            //}
            //collisionManager = new CollisionManager(colliders, hero);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentLevel = new FirstLevel(GraphicsDevice, Content);

            // TODO: use this.Content to load your game content here

            //foreach (Animation animation in hero.Animator.Animations)
            //{
            //    animation.SpriteSheet = Content.Load<Texture2D>(animation.SpriteSheetPath);
            //}

            //foreach (IMapObject block in mapMaker.Blocks)
            //{
            //    block.Spritesheet = Content.Load<Texture2D>(block.SpritesheetPath);
            //}
        }


        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _currentLevel.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _currentLevel.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}
