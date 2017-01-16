using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;

namespace PongGongOnlineDeluxe
{
    
    public class Game1 : Game
    {
        string clientPlayer = "Player 1";
        Ball ball;
        Paddle paddle1, paddle2;
        Texture2D sprBall, sprPaddle;
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
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprBall = Content.Load<Texture2D>("ball");
            sprPaddle = Content.Load<Texture2D>("paddle");
            ball.BallConstructor(sprBall, new Vector2(250, 250), 50, 50, 5,new Vector2(-5,2));
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
            if((ball.hitbox.Intersects(paddle1.hitbox) && ball.velocity.X < 0) || (ball.hitbox.Intersects(paddle2.hitbox) && ball.velocity.X > 0))
            {
                ball.velocity.X *= -1;
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
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
