﻿using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.LevelManagement.Levels
{
    public class SecondLevel : Level
    {
        public override int LevelId { get; set; } = 2;

        public SecondLevel(GraphicsDevice graphicsDevice, ContentManager content, Game1 game) : base(graphicsDevice, content, game) { }

        protected override void Initialize()
        {
            endzone = new EndingZone(new Vector2(1500, 0), "Ending zone", 62, 62);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (endzone.CheckEnding(hero)) _game.ChangeLevel(new FirstLevel(_graphics, _content, _game));
            base.Update(gameTime);
        }
    }
}