using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace explosion.View
{
    class Camera
    {
        private float scale;
        private static int borderIndent = 10;

        public Camera(int width, int heigth)
        {
            int scaleX = (width - borderIndent * 2);
            int scaleY = (heigth - borderIndent * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public Rectangle scaleParticle(float xPos, float yPos, float size)
        {
            int vSize = (int)(size * scale);

            Vector2 smokeVector = scaleparticleVector(xPos, yPos);

            return new Rectangle((int)smokeVector.X, (int)smokeVector.Y, vSize, vSize);
        }

        public Vector2 scaleparticleVector(float xPos, float yPos)
        {
            float vX = (xPos * scale + borderIndent);
            float vY = (yPos * scale + borderIndent);

            return new Vector2(vX, vY);
        }

        public float Scale
        {
            get { return scale; }
        }
    }
}
