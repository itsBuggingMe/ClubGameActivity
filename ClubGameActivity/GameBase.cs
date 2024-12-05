using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace ClubGameActivity
{
    public partial class GameBase : Game
    {
        Color BackgroundColor = Color.CornflowerBlue;
        Texture2D _texture;
        const string url = "https://www.wabash.edu/images2/technology/canvas.png";

        void Initalize()
        {
            WindowWidth = 1280;
            WindowHeight = 720;

            _texture = FromWeb(url);
        }

        void Update()
        {
            //this method is run 60x a second
            Debug.WriteLine("Update called!");
        }

        void Draw()
        {
            //this is run right after "Update"
            _spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
        }
    }
}