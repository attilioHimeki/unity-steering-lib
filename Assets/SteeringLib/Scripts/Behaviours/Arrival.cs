using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Arrival : SteeringBehaviour
    {
        public float decelerationFactor = 0.3f;

        public Arrival(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            var distanceVector = owner.target.getPosition() - owner.getPosition();
            var distance = distanceVector.magnitude;

            if(distance > Mathf.Epsilon)
            {
                float speed = Mathf.Min(owner.getMaxSpeed(), distance / decelerationFactor);
                Vector3 desiredVelocity = distanceVector * speed / distance;
                var steering = desiredVelocity - owner.getVelocity();
                return steering;
            }

            return Vector3.zero;
        }
    }
}