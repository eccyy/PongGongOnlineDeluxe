using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using System;

namespace PongGongOnlineDeluxe
{
    
    public class Game1 : Game
    {
        string clientPlayer = "Player 1";
        int paddle1Score, paddle2Score;
        Ball ball;
        Random rng;
        Paddle paddle1, paddle2;
        Texture2D sprBall, sprPaddle;
        SpriteFont font;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            ball = new Ball();
            paddle1 = new Paddle();
            paddle2 = new Paddle();
            rng = new Random();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprBall = Content.Load<Texture2D>("ball");
            sprPaddle = Content.Load<Texture2D>("paddle");
            font = Content.Load<SpriteFont>("font");
            ball.BallConstructor(sprBall, new Vector2(250, 250), 25, 25, 4, RandomizeDirection(rng.Next(1,5)));
            paddle1.PaddleConstructor(sprPaddle, new Vector2(20, 150), 10, 100, 5, "Player 1");
            paddle2.PaddleConstructor(sprPaddle, new Vector2(470, 150), 10, 100, 5, "Player 1");
        }


        protected override void UnloadContent()
        {
        }

        
        protected override void Update(GameTime gameTime)
        {
            KeyboardState pressedKeys = Keyboard.GetState();
            #region Player movement
            if(pressedKeys.IsKeyDown(Keys.Up))
            {
                if(paddle1.player == clientPlayer)
                {
                    if(paddle1.position.Y > 0)
                    {
                        paddle1.position.Y -= paddle1.speed;
                    }
                }

                if(paddle2.player == clientPlayer)
                {
                    if (paddle2.position.Y > 0)
                    {
                        paddle2.position.Y -= paddle1.speed;
                    }
                }
            }

            if (pressedKeys.IsKeyDown(Keys.Down))
            {
                if (paddle1.player == clientPlayer)
                {
                    if (paddle1.position.Y < 500-paddle1.height)
                    {
                        paddle1.position.Y += paddle1.speed;
                    }
                }

                if (paddle2.player == clientPlayer)
                {
                    if (paddle2.position.Y < 500-paddle2.height)
                    {
                        paddle2.position.Y += paddle2.speed;
                    }
                }
            }
            #endregion
            if(ball.hitbox.Intersects(paddle1.hitbox) && ball.velocity.X < 0)
            {
                ball.velocity = Hit(ball.position, ball.width,ball.height,paddle1.position,paddle1.width,paddle1.height);
            }

            if (ball.hitbox.Intersects(paddle2.hitbox) && ball.velocity.X > 0)
            {
                ball.velocity = Hit(ball.position, ball.width, ball.height, paddle2.position, paddle2.width, paddle2.height);
            }

                if (ball.position.X <= 0)
            {
                ball.position = ball.startPosition;
                ball.velocity = RandomizeDirection(rng.Next(1, 5));
                paddle2Score++;
            }
            else if(ball.position.X >= 500-ball.width)
            {
                ball.position = ball.startPosition;
                ball.velocity = RandomizeDirection(rng.Next(1, 5));
                paddle1Score++;
            }
            paddle1.Update();
            paddle2.Update();
            ball.Update();
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(ball.sprite,new Rectangle((int)ball.position.X,(int)ball.position.Y,ball.width,ball.height),Color.White);
            spriteBatch.Draw(paddle1.sprite, new Rectangle((int)paddle1.position.X, (int)paddle1.position.Y, paddle1.width, paddle1.height), Color.Black);
            spriteBatch.Draw(paddle2.sprite, new Rectangle((int)paddle2.position.X, (int)paddle2.position.Y, paddle2.width, paddle2.height), Color.Black);
            spriteBatch.DrawString(font, paddle1Score.ToString(), new Vector2(60, 0),Color.Black);
            spriteBatch.DrawString(font, paddle2Score.ToString(), new Vector2(440-font.MeasureString(paddle2Score.ToString()).X, 0), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public Vector2 RandomizeDirection(int rand)
        {
            if (rand == 1)
            {
                return new Vector2(5, 5);
            }
            else if (rand == 2)
            {
                return new Vector2(-5, -5);
            }
            else if (rand == 3)
            {
                return new Vector2(5, -5);
            }
            else if (rand == 4)
            {
                return new Vector2(-5, 5);
            }
            else
                return new Vector2(5, 5);
        }

        private Vector2 Hit(Vector2 ballPos, int ballWidth, int ballHeight, Vector2 paddlePos, int paddleWidth, int paddleHeight)
        {
            Vector2 ballMiddle = new Vector2(ballPos.X + ballWidth / 2, ballPos.Y + ballHeight / 2);
            Vector2 paddleMiddle = new Vector2(paddlePos.X + paddleWidth / 2, paddlePos.Y + paddleHeight / 2);
            Vector2 normalizedBallPos = ballMiddle - paddleMiddle;
            float angle = (normalizedBallPos.Y / (paddleHeight / 2)) * 60;
            int dir = -Math.Sign(normalizedBallPos.X);
            return new Vector2(dir * (float)Math.Cos(angle),-(float)Math.Sin(angle));
        }
    }
}
