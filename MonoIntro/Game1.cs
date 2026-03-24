using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Helpers.RGB;

namespace MonoIntro;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RgbHelper RGB;
    
    // SPRITES
    private Texture2D pixel;

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

        pixel = new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData(new[] {Color.White});
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float speed = 60f;
        RGB._hue += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (RGB._hue >= 360f) RGB._hue -= 360f;
        
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(RGB.HsvToRgb(RGB._hue, 1f, 1f));

        _spriteBatch.Begin();
        
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}