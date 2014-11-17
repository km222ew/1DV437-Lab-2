using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace splittergrav.View
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

        public Rectangle scaleSplitter(float xPos, float yPos, float splitterSize)
        {
            int vSize = (int)(splitterSize * scale);

            int vX = (int)(xPos * scale + borderIndent);
            int vY = (int)(yPos * scale + borderIndent);

            return new Rectangle(vX, vY, vSize, vSize);
        }
        
    }
}
