using UnityEngine;

namespace UnitySteeringLib
{
    public class PlayerControlledAgent : Agent
    {

        protected override void setupMovementModule()
        {
            movementModule = new SimpleInputMovementModule(this);
        }

        public override void update(float dt)
        {
            var steering = movementModule.getStep(dt);
            if (steering.sqrMagnitude > Mathf.Epsilon)
            {
                var movementStep = steering * dt;
                setForward(steering.normalized);
                translate(movementStep);
            }
        }

    }
}
