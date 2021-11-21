using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class HandleOffScreenAction : Action
    {
        
        BounceActorService _bounceActorService;
        public HandleOffScreenAction(BounceActorService bounceActorService)
        {
            _bounceActorService = bounceActorService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor actor in cast["balls"])
            {
                int x = actor.GetX();
                int y = actor.GetY();

                if (x <= 0 || x >= Constants.MAX_X)
                {
                    _bounceActorService.Bounce(actor, "x");
                }
                
                if (y <= 0 || y >= Constants.MAX_Y)
                {
                    _bounceActorService.Bounce(actor, "y");
                }
            }
            
        }

        
    }
}