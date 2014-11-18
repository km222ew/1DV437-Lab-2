using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace smoke.View
{
    class SmokeSystem
    {
        private List<SmokeParticle> particles = new List<SmokeParticle>();
        private float totalTime = 0;
        private static float delay = 0.2f;
        
        private static float MAX_PARTICLES = 50;

        private Camera camera;

        public SmokeSystem(Viewport viewPort)
        {
            camera = new Camera(viewPort.Width, viewPort.Height);
        }

        public void Update(float timeElapsed)
        {
            totalTime += timeElapsed;

            if (totalTime >= delay)
            {
                totalTime = 0;

                if(particles.Count < MAX_PARTICLES)
                {
                    particles.Add(new SmokeParticle());
                }                
            }

            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update(timeElapsed);

                if (particles[i].IsDead())
                {
                    particles[i].Respawn();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
    
}
