using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;

namespace PongGongOnlineDeluxe
{
    
    public class Game1 : Game
    {
        Ball ball;
        Texture2D sprBall, sprPaddle;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            ball = new Ball();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sprBall = Content.Load<Texture2D>("ball");
            sprPaddle = Content.Load<Texture2D>("paddle");
            ball.sprite = sprBall;
        }


        protected override void UnloadContent()
        {
        }

        
        protected override void Update(GameTime gameTime)
        {


            ball.Update();
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(ball.sprite,new Rectangle((int)ball.position.X,(int)ball.position.Y,ball.width,ball.height),Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
