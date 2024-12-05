using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClubGameActivity
{
    public partial class GameBase : Game
    {
        public static void Main()
        {
            using var game = new GameBase();
            game.Run();
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private HttpClient _httpClient;

        private int WindowWidth { get => _graphics.PreferredBackBufferWidth; set => _graphics.PreferredBackBufferWidth = value; }
        private int WindowHeight { get => _graphics.PreferredBackBufferHeight; set => _graphics.PreferredBackBufferHeight = value; }

        public GameBase()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _httpClient = new HttpClient();
        }

        protected override void Initialize()
        {
            Initalize();
            base.Initialize();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColor);
            _spriteBatch.Begin();
            Draw();
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public Texture2D FromWeb(string url)
        {
            var s = _httpClient.GetStreamAsync(url).Result;
            return Texture2D.FromStream(GraphicsDevice, s);
        }
    }
}
