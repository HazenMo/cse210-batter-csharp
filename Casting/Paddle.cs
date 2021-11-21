using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class Paddle : Actor
    {
        public Paddle(int x, int y)
        {
            _height = Constants.PADDLE_HEIGHT;
            _width = Constants.PADDLE_WIDTH;
            _position = new Point(x, y);
            SetImage(Constants.IMAGE_PADDLE);
        }
        
    }
}