using UnityEngine;

namespace UnitySteeringLib
{
    public class Arrival : SteeringBehaviour
    {
        public float arrivalRadius = 5f;
        public float arrivalMinDistance = 2f;

        public Arrival(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            var desiredVelocity = owner.target.getPosition() - owner.getPosition();

            var distance = desiredVelocity.magnitude;
            if(distance >= arrivalMinDistance)
            {
                if (distance < arrivalRadius)
                {
                    desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed() * ((distance - arrivalMinDistance) / arrivalRadius);
                }
                else
                {
                    desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed();
                }

                var steering = desiredVelocity - owner.getVelocity();
                return steering;
            }
            return Vector3.zero;
        }
    }
}