using UnityEngine;

namespace UnitySteeringLib
{
    public class PlayerControlledAgent : Agent
    {
        protected override void setupMovementModule()
        {
            movementModule = new SimpleInputMovementModule(this);
        }

    }
}
