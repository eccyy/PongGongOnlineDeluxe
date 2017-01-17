using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGongOnlineDeluxe
{
    class Ball
    {
        public Texture2D sprite;
        public Rectangle hitbox;
        public Vector2 position, startPosition;
        public int width, height;
        public float speed;
        public Vector2 velocity;
        public Vector2 startVelocity;

        public void BallConstructor(Texture2D spr, Vector2 pos, int w, int h, float sp, Vector2 stVel)
        {
            this.sprite = spr;
            this.position = pos;
            this.startPosition = position;
            this.width = w;
            this.height = h;
            this.speed = sp;
            this.startVelocity = stVel;
            this.velocity = startVelocity;
        }

        public void Update()
        {
            if(position.Y < 0 || position.Y > 500-height)
            {
                velocity.Y *= -1;
            }
            hitbox = new Rectangle((int)position.X,(int)position.Y,width,height);
            velocity.Normalize();
            velocity *= speed;
            position += velocity;
        }
    }
}
