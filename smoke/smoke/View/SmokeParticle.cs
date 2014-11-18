using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace smoke.View
{
    class SmokeParticle
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        private static float maxSpeed = 0.2f;

        private float maxTimeToLive = 3.0f;
        private float lifePercent;
        private float minSize = 3f;
        private float maxSize = 6f;
        private float angle = 0;

        private float timeLived;
        private float size;

        
        public SmokeParticle()
        {
            acceleration = new Vector2(0, -0.4f);
            Respawn();
        }

        public void Respawn()
        {
            timeLived = 0;

            position = new Vector2(0.5f, 0.9f);

            size = 0;

            Random rand = new Random();

            velocity = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
            velocity.Normalize();
            velocity = velocity * ((float)rand.NextDouble() * maxSpeed);
        }

        public bool IsDead()
        {
            return timeLived >= maxTimeToLive;
        }

        public void Update(float timeElapsed)
        {
            angle += 0.01f;

            timeLived += timeElapsed;
            lifePercent = timeLived / maxTimeToLive;
            size = minSize + lifePercent * maxSize;

            Vector2 newPos = new Vector2();
            Vector2 newVel = new Vector2();

            newVel.X = velocity.X + timeElapsed * acceleration.X;
            newVel.Y = velocity.Y + timeElapsed * acceleration.Y;

            newPos.X = position.X + timeElapsed * velocity.X;
            newPos.Y = position.Y + timeElapsed * velocity.Y;

            velocity = newVel;
            position = newPos;

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D smokeTexture, Camera camera)
        {

            float t = timeLived / maxTimeToLive;
            if (t > 1.0f)
            {
                t = 1.0f;
                return;
            }

            float startValue = 1.0f;
            float endValue = 0.0f;

            float fade = endValue * t + (1.0f - t) * startValue;

            Color color = new Color(fade, fade, fade, fade);

            Vector2 origin = new Vector2(smokeTexture.Bounds.Width / 2, smokeTexture.Bounds.Height / 2);

            spriteBatch.Begin();
            spriteBatch.Draw(smokeTexture, camera.scaleSmokeVector(position.X, position.Y), new Rectangle(0, 0, smokeTexture.Bounds.Width, smokeTexture.Bounds.Height), color, angle, origin, size, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
    
}
