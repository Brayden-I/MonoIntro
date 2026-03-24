using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Helpers.RGB;

namespace MonoIntro;

public class Game1 : Game
{
    // FIELDS
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RgbHelper RGB;
    
    private float _slugRot = 0f;
    
    private Vector2 _playerPos = Vector2.Zero;
    
    // SPRITES
    private Texture2D _pixel;
    private Texture2D _bipedoTexture; //BipedoPeak
    private Texture2D _slugballTexture; //SlugBall
    private Texture2D _playerIdleTexture;
    private Texture2D _playerShootTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        RGB = new RgbHelper();
    }

    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

       _pixel = new Texture2D(GraphicsDevice, 1, 1);
       _pixel.SetData(new[] {Color.White});
        
        // IMAGE SPRITES
        _bipedoTexture = Content.Load<Texture2D>("BipedoPeek");
        _slugballTexture = Content.Load<Texture2D>("SlugBall");
        
        _playerIdleTexture = Content.Load<Texture2D>("PlayerIdle");
        _playerShootTexture = Content.Load<Texture2D>("PlayerShoot");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        // Delta Time
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        // Keyboard
        var kb = Keyboard.GetState();
        
        // RGB BACKGROUND
        float rgb_speed = 60f;
        RGB._hue += rgb_speed * dt;
        if (RGB._hue >= 360f) RGB._hue -= 360f;
        
        // Rotating slug
        _slugRot += dt;
        
        // Moving Player
        float speed = 200f;
        
        //movement
        if (kb.IsKeyDown(Keys.W)) _playerPos.Y -= speed * dt;
        if (kb.IsKeyDown(Keys.S)) _playerPos.Y += speed * dt;
        if (kb.IsKeyDown(Keys.A)) _playerPos.X -= speed * dt;
        if (kb.IsKeyDown(Keys.D)) _playerPos.X += speed * dt;
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(RGB.HsvToRgb(RGB._hue, 1f, 1f));

        _spriteBatch.Begin();
        
        _spriteBatch.Draw(_pixel, new Rectangle(100, 100, 50, 50 ), Color.Red);
        _spriteBatch.Draw(_bipedoTexture, new Rectangle(0, 0, 100,100), Color.White);
        
        // Rotating slug
        _spriteBatch.Draw(
            _slugballTexture,
            new Vector2(200, 200),                              // Vector2 position
            null,                                               // Rectangle? sourceRectangle
            Color.White,                                        // Color color
            _slugRot,                                          // float rotation
            new Vector2(_slugballTexture.Width / 2f, _slugballTexture.Height / 2f), // Vector2 origin
            1f,                                                 // float scale
            SpriteEffects.None,                                 // SpriteEffects effects
            0f                                                  // float layerDepth
        );
        
        // Player
        _spriteBatch.Draw(
            _playerIdleTexture,
            _playerPos,
            null,
            Color.White
        );
        
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}