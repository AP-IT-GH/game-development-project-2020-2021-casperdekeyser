using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MakingAPlatformer
{
    public class JumpCommand
    {
        private bool rising = false;
        private bool falling = false;
        private bool jumping = false;
        private int jumpSpeed = 5;
        private int jumpHeight = 150;
        private float startY;
        private float ground;

        public float CurrentHeight;


        public JumpCommand(int speed, int height, float ground)
        {
            jumpSpeed = speed;
            jumpHeight = height;
            startY = ground;
            CurrentHeight = ground;
            this.ground = ground;
        }

        public void CheckJumping()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space) && (!jumping) && (!falling))
            {
                Hero.State = States.Jumping;
                rising = true;
            }
        }

        public void Execute(IGameObject Hero)
        {
            if (falling && !CollisionManager.VerticalColliding)
            {
                CurrentHeight += jumpSpeed; // falling speed
                Hero.Position = new Vector2(Hero.Position.X, CurrentHeight);
                Hero.Direction = new Vector2(Hero.Position.X, CurrentHeight);

                if (Hero.Position.Y >= startY)
                {
                    Hero.Position = new Vector2(Hero.Position.X, startY);
                    falling = false;
                    MakingAPlatformer.Hero.State = States.Idling;
                    jumping = false;
                    startY = Hero.Position.Y;
                }
            }

            if (rising)
            {
                jumping = true;
                Hero.Position = new Vector2(Hero.Position.X, CurrentHeight);
                if (Hero.Position.Y <= startY - jumpHeight)
                {
                    rising = false;
                    falling = true;
                }
                CurrentHeight -= jumpSpeed; // rising speed
            }

            if (CollisionManager.VerticalColliding)
            {
                MakingAPlatformer.Hero.State = States.Idling;
                jumping = false;
                falling = false;
                startY = Hero.Position.Y;
            }

            else
            {
                if(!jumping)
                    startY = ground; // FIX
            }

            if (!CollisionManager.VerticalColliding && (!jumping) && (Hero.Position.Y < ground))
            {
                falling = true;
            }
        }
    }
}
