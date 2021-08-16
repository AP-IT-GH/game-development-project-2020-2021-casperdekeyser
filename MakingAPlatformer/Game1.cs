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

        // Hero
        IGameObject hero;
        Vector2 heroPosition;
        HeroAnimator heroAnimator;
        IInputReader inputReader;
        AnimateCommand animateCommand;

        // Map
        int xMap = 15;
        int yMap = 25;

        List<IMapObject> blocks = new List<IMapObject>();
        public Block[,] blockArray = new Block[15, 25];
        public byte[,] tileArray = new byte[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };

        public void CreateWorld()
        {
            for (int x = 0; x < xMap; x++)
            {
                for (int y = 0; y < yMap; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blockArray[x, y] = new Block(new Vector2(y * 62, x * 62));
                        blocks.Add(blockArray[x, y]);
                    }
                }
            }
        }

        // Collision
        CollisionManager collisionManager;
        List<BoxCollider> colliders;


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


            // Objects
            // Hero
            heroPosition = new Vector2(100, 868-96); //y 250
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroPosition, heroAnimator, inputReader, animateCommand);

            // Map
            //blocks = new List<IMapObject>
            //{
            //    new Block(new Vector2(300, 280)),
            //    new Block(new Vector2(400, 280)),
            //    new Block(new Vector2(500, 280)),
            //    new Block(new Vector2(500, 220)),
            //    new Block(new Vector2(500, 500))
            //};

            CreateWorld();

            // Collision
            colliders = new List<BoxCollider>();
            foreach (IMapObject block in blocks)
            {
                colliders.Add(block.Collider);
            }
            collisionManager = new CollisionManager(colliders, hero);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            foreach (Animation animation in hero.Animator.Animations)
            {
                animation.SpriteSheet = Content.Load<Texture2D>(animation.SpriteSheetPath);
            }

            foreach (IMapObject block in blocks)
            {
                block.Spritesheet = Content.Load<Texture2D>(block.SpritesheetPath);
            }
        }


        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            collisionManager.Execute();
            hero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            //foreach (IMapObject block in blocks)
            //{
            //    block.Draw(_spriteBatch);
            //}

            for (int x = 0; x < xMap; x++)
            {
                for (int y = 0; y < yMap; y++)
                {
                    if (blockArray[x, y] != null)
                    {
                        blockArray[x, y].Draw(_spriteBatch);
                    }
                }
            }

            // DRAW COLLIDERS
            //collisionManager.DrawColliders(_spriteBatch, GraphicsDevice);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
