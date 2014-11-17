using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace splittergrav.View
{
    class SplitterSystem
    {
        private SplitterParticle[] particles;
        private int NUM_PARTICLES = 100;
        private float totalTime = 0;
        private static float MAX_TIME = 2;
        private static float maxSpeed = 0.2f;

        private Camera camera;

        public SplitterSystem(Viewport viewPort)
        {
            camera = new Camera(viewPort.Width, viewPort.Height);

            particles = new SplitterParticle[NUM_PARTICLES];

            spawnNewSystem();
        }

        private void spawnNewSystem()
        {                      
            Random rand = new Random();

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                Vector2 velocity = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
                velocity.Normalize();
                velocity = velocity * ((float)rand.NextDouble() * maxSpeed);

                particles[i] = new SplitterParticle(velocity);
            }
        }

        public void Update(float timeElapsed)
        {
            totalTime += timeElapsed;

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                particles[i].Update(timeElapsed);
            }

            if (totalTime > MAX_TIME)
            {
                totalTime = 0;
                spawnNewSystem();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture)
        {
            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                particles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
}
