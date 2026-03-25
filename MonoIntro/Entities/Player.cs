using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoIntro.Entities;

public class Player : Entity
{
    private Texture2D _shootTexture;
    private SpriteEffects _flip = SpriteEffects.None;
    private float _speed = 200f;
    private Viewport _vp;
    private bool _isShooting;

    public Player(Texture2D idleTexture, Texture2D shootTexture, Viewport vp, Vector2 startPos)
        : base(idleTexture, startPos)
    {
        _shootTexture = shootTexture;
        _vp = vp;
    }

    public override void Update(GameTime gameTime, float deltaTime)
    {
        var kb = Keyboard.GetState();
        
        // Movement
        Velocity = Vector2.Zero;
        if (kb.IsKeyDown(Keys.W)) Velocity.Y = -_speed;
        if (kb.IsKeyDown(Keys.S)) Velocity.Y =  _speed;
        if (kb.IsKeyDown(Keys.A)) { Velocity.X = -_speed; _flip = SpriteEffects.FlipHorizontally; }
        if (kb.IsKeyDown(Keys.D)) { Velocity.X =  _speed; _flip = SpriteEffects.None; }

        // Shooting
        _isShooting = kb.IsKeyDown(Keys.Space);

        base.Update(gameTime, deltaTime);

        // Clamp after base moves position
        Position.X = MathHelper.Clamp(Position.X, 0, _vp.Width - Texture.Width * Scale);
        Position.Y = MathHelper.Clamp(Position.Y, 0, _vp.Height - Texture.Height * Scale);
    }
    
    public override void Draw(SpriteBatch sb)
    {
        sb.Draw(
            _isShooting ? _shootTexture : Texture,
            Position,
            null,
            Color.White,
            Rotation,
            Vector2.Zero,
            Scale,
            _flip,
            0f
        );
    }
}
