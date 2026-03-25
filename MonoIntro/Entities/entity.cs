using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoIntro.Entities;

public class Entity
{
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    public float Rotation;
    public float Scale;
    
    public Texture2D Texture;
    
    public Entity(Texture2D texture2D, Vector2 position, float scale = 1f, float rotation = 0f, 
        Vector2 velocity = default, Vector2 acceleration = default)
    {
        Texture = texture2D;
        Position = position;
        Scale = scale;
        Rotation = rotation;
        Velocity = velocity;
        Acceleration = acceleration;
    }

    public virtual void Update(GameTime gameTime, float deltaTime)
    {
        Velocity += Acceleration * deltaTime;
        Position += Velocity * deltaTime;
    }

    public virtual void Draw(SpriteBatch sb)
    {
        sb.Draw(
            Texture,
            Position,
            null,
            Color.White,
            Rotation,
            Vector2.Zero,
            Scale,
            SpriteEffects.None,
            0f
        );
    }
}