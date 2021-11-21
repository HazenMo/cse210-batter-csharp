using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class BounceActorService
    {
        AudioService _audioService = new AudioService();

        public BounceActorService(AudioService audioService)
        {
            _audioService = audioService;
        }

        public void Bounce(Actor actor, string direction)
        {

            int dx = actor.GetVelocity().GetX();
            int dy = actor.GetVelocity().GetY();

            
            if (direction == "x")
            {
                actor.SetVelocity(new Point((dx * -1), dy));
                _audioService.PlaySound(Constants.SOUND_BOUNCE);
            }

            if (direction == "y")
            {
                actor.SetVelocity(new Point(dx, (dy * -1)));
                _audioService.PlaySound(Constants.SOUND_BOUNCE);
            }
        }
    }
}