using UnityEngine;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {
        private Vector3 stepSeek(Vector3 targetPosition)
        {
            var desiredVelocity = targetPosition - owner.getPosition();
            desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed();

            var steering = desiredVelocity - owner.getVelocity();

            return steering;
        }
    }

}