using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class Ball : Actor
    {
        public Ball(int x, int y)
        {
            _height = Constants.BALL_HEIGHT;
            _width = Constants.BALL_WIDTH;
            _position = new Point(x, y);
            SetImage(Constants.IMAGE_BALL);
            _velocity = new Point(Constants.BALL_DX, Constants.BALL_DY);
        }
        
    }
}