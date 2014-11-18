using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace explosion.View.ParticleSystems
{
    class FireParticle
    {
        Texture2D explosionTexture;

        private Vector2 position;
        private float timeElapsed;
        private float maxTime = 2f;
        private int numberOfFrames = 24;
        private int numFramesX = 4;
        private int frameSize;
        private float scaledFrameSize = 0.2f;

        Camera camera;

        public FireParticle(Viewport viewPort, Vector2 position, ContentManager content)
        {
            explosionTexture = content.Load<Texture2D>("explosion");
            
            camera = new Camera(viewPort.Width, viewPort.Height);

            frameSize = explosionTexture.Bounds.Width / numFramesX;

            scaledFrameSize = scaledFrameSize * camera.Scale;

            this.position = position;
        }

        public void Update(float elapsedTime)
        {
            timeElapsed += elapsedTime;
            if (timeElapsed >= maxTime)
            {
                timeElapsed = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {          
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            int frameX = frame % numFramesX;
            int frameY = frame / numFramesX;

            Vector2 scalePos = camera.scaleparticleVector(position.X, position.Y);
            

            spriteBatch.Begin();
            //camera.scaleParticle(position.X, position.Y, frameSize)
            spriteBatch.Draw(explosionTexture, new Rectangle((int)scalePos.X - (int)scaledFrameSize / 2, (int)scalePos.Y - (int)scaledFrameSize / 2, (int)scaledFrameSize, (int)scaledFrameSize), new Rectangle(frameX * frameSize, frameY * frameSize, frameSize, frameSize), Color.White);

            spriteBatch.End();
        }
    }
}
