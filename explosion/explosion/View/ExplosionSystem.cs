using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using explosion.View.ParticleSystems;

namespace explosion.View
{
    class ExplosionSystem
    {
        private Vector2 position;

        private SmokeSystem smokeSystem;
        private SplitterSystem splitterSystem;
        private FireParticle fireParticle;

        public ExplosionSystem(Viewport viewPort, ContentManager content)
        {
            position = new Vector2(0.5f, 0.5f);
            smokeSystem = new SmokeSystem(viewPort, position, content);
            splitterSystem = new SplitterSystem(viewPort, position, content);
            fireParticle = new FireParticle(viewPort, position, content);
            
            
        }

        public void Update(float timeElapsed)
        {
            smokeSystem.Update(timeElapsed);      
            splitterSystem.Update(timeElapsed);
            fireParticle.Update(timeElapsed);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            smokeSystem.Draw(spriteBatch);
            splitterSystem.Draw(spriteBatch);
            fireParticle.Draw(spriteBatch);
        }
    }
}
