﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gymnaieprojekt
{
    public class Sprite
    {
        private Texture2D texture;
        protected Vector2 position;
        protected Vector2 scale;
        protected Rectangle srcRect;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;

        public Sprite(Texture2D texture, Vector2 position, Vector2 size, Color? color = null, Rectangle? srcRect = null, Vector2? origin = null )
        {
            this.texture = texture;
            this.position = position;
            scale = size/texture.Bounds.Size.ToVector2();
            this.srcRect = srcRect ?? texture.Bounds;
            this.color = color ?? Color.White;
            this.origin = origin ?? Vector2.Zero;
        }

        protected Sprite(Vector2 position, Rectangle srcRect, Color? color = null, float rotation = 0, Vector2? origin = null)
        {
            scale = new Vector2(1 , 1);
            this.position = position;
            this.srcRect = srcRect;
            this.color = color ?? Color.White;
            this.rotation = rotation;
            this.origin = origin ?? Vector2.Zero;
        }

        Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        float X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        Vector2 Size
        {
            get { return scale * texture.Bounds.Size.ToVector2(); }
            set { scale = value / texture.Bounds.Size.ToVector2(); }
        }
        float Width
        {
            get { return scale.X * texture.Width; }
            set { scale.X = value / texture.Width; }
        }
        float Height
        {
            get { return scale.Y * texture.Height; }
            set { scale.Y = value / texture.Height; }
        }

        float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public void Move(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        public void Center()
        {
            origin = texture.Bounds.Size.ToVector2() / 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: texture,
                position: position,
                scale: scale,
                sourceRectangle: srcRect,
                color: Color.White,
                rotation: rotation,
                origin: origin,
                effects: SpriteEffects.None,
                layerDepth: 0
            );
        }
    }
}
