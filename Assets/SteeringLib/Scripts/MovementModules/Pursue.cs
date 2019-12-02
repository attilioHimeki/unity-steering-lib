using UnityEngine;

namespace UnitySteeringLib
{
	public partial class SteeringMovementModule : MovementModule 
	{
        private Vector3 stepPursue(IAgent target)
        {
            var posDistance = target.getPosition() - owner.getPosition();

            var pursueVelocity = target.getVelocity();

            var anticipationMultiplier = posDistance.magnitude / owner.getMaxSpeed();
            var pursueTargetPos = target.getPosition() + pursueVelocity * anticipationMultiplier;

            return stepSeek(pursueTargetPos);
        }

    }
}