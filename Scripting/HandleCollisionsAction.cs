using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;
using System;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        PhysicsService _physicsService = new PhysicsService();
        Ball _ball;
        BounceActorService _bounceActorsService;
        List<Actor> _removalList = new List<Actor>();
        

        public HandleCollisionsAction(PhysicsService physicsService, Ball ball, BounceActorService bounceActorService)
        {
            _physicsService = physicsService;
            _ball = ball;
            _bounceActorsService = bounceActorService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
        
            foreach (Actor actor in cast["paddle"])
            {
                if (_physicsService.IsCollision(actor, _ball))
                {
                    _bounceActorsService.Bounce(_ball, "y");
                }
            }

            foreach (Actor actor in cast["bricks"])
            {
                if (_physicsService.IsCollision(actor, _ball))
                {
                    _bounceActorsService.Bounce(_ball, "y");
                    _removalList.Add(actor);
                }
            }
            
            foreach (Actor actor in _removalList)
            {
                cast["bricks"].Remove(actor);
            }
        }        
    }
}