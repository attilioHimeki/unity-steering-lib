using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Flee : SteeringBehaviour
    {
        public float safeFleeDistance = 10f;

        public Flee(SteeringAgent owner)
        : base(owner)
        {
        }
        
        public override Vector3 step()
        {
            var distanceVector = owner.target.getPosition() - owner.getPosition();
            var distance = distanceVector.magnitude;
            if (distance < safeFleeDistance)
            {
                var desiredVelocity = distanceVector.normalized * owner.getMaxSpeed();
                var steering = desiredVelocity - owner.getVelocity();
                return -steering;
            }

            return -owner.getVelocity();
        }

    }
}