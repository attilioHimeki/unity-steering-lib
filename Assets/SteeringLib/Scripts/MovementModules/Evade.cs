using UnityEngine;

namespace UnitySteeringLib
{
	public partial class SteeringMovementModule : MovementModule 
	{
        private Vector3 stepEvade(Vector3 targetPosition)
        {
            var target = steeringOwner.getTarget();
            var posDistance = targetPosition - owner.getPosition();
            var pursueVelocity = target.getVelocity();

            var anticipationMultiplier = posDistance.magnitude / owner.getMaxSpeed();
            var pursueTargetPos = targetPosition + pursueVelocity * anticipationMultiplier;

            return stepFlee(pursueTargetPos);
        }
    }
}