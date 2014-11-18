﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace explosion.View.ParticleSystems
{
    class SplitterSystem
    {
        private Vector2 position;
        private Texture2D splitterTexture;
        private SplitterParticle[] particles;
        private int NUM_PARTICLES = 100;
        private float totalTime = 0;
        private static float MAX_TIME = 2;
        private static float maxSpeed = 0.3f;

        private Camera camera;

        public SplitterSystem(Viewport viewPort, Vector2 position, ContentManager content)
        {
            camera = new Camera(viewPort.Width, viewPort.Height);
            this.position = position;

            splitterTexture = content.Load<Texture2D>("spark");

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

                particles[i] = new SplitterParticle(velocity, position);
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

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                particles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
}
