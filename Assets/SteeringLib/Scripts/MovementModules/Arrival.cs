using UnityEngine;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {
        [Header("Arrival")]
        public float arrivalRadius = 5f;
        public float arrivalMinDistance = 2f;

        public Vector3 stepArrival(Vector3 targetPosition)
        {
            var desiredVelocity = targetPosition - owner.getPosition();

            var distance = desiredVelocity.magnitude;

            if (distance < arrivalRadius)
            {
                desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed() * ((distance - arrivalMinDistance) / arrivalRadius);
            }
            else
            {
                desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed();
            }

            var steering = desiredVelocity - velocity;
            return steering;
        }
    }
}