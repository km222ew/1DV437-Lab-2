using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2danimation.View
{
    class AnimatedSprite
    {
        Texture2D explosionTexture;

        private Vector2 position;
        private float timeElapsed;
        private float maxTime = 0.5f;
        private int numberOfFrames = 24;
        private int numFramesX = 4;
        private int frameSize;

        public AnimatedSprite(Texture2D texture, Viewport viewPort)
        {
            explosionTexture = texture;
            frameSize = explosionTexture.Bounds.Width / numFramesX;

            position = new Vector2((viewPort.Width - frameSize) / 2, (viewPort.Height - frameSize) / 2);
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

            spriteBatch.Begin();

            spriteBatch.Draw(explosionTexture, position, new Rectangle(frameX * frameSize, frameY * frameSize, frameSize, frameSize), Color.White);

            spriteBatch.End();
        }
    }
}
