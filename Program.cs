using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();

            // TODO: Add your bricks here
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Brick brick = new Brick((j * 60 + 15), (i * 35 + 10));
                    cast["bricks"].Add(brick);
                }
            }

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            // TODO: Add your ball here
            Ball ball = new Ball(400, 300);
            cast["balls"].Add(ball);

            // The paddle
            cast["paddle"] = new List<Actor>();

            // TODO: Add your paddle here
            Paddle paddle = new Paddle(Constants.PADDLE_X, Constants.PADDLE_Y);
            cast["paddle"].Add(paddle);

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();
            BounceActorService bounceActorService = new BounceActorService(audioService);

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.

            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);
            HandleOffScreenAction handleOffScreenAction = new HandleOffScreenAction(bounceActorService);
            script["update"].Add(handleOffScreenAction);
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, ball, bounceActorService);
            script["update"].Add(handleCollisionsAction);
            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
