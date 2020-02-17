using UnityEngine;

namespace UnitySteeringLib
{
    public class Follow : SteeringBehaviour
    {
        public float followDistance = 3f;
        public float minFollowSpeed = 0.3f;

        public Follow(SteeringAgent owner)
        : base(owner)
        {
        }
        
        public override Vector3 step()
        {
            var offset = -owner.target.getForward() * followDistance;
            var targetFollowPos = owner.target.getPosition() + offset;
            var desiredVelocity = targetFollowPos - owner.getPosition();

            if(desiredVelocity.sqrMagnitude >= minFollowSpeed * minFollowSpeed)
            {
                desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed();
                var steering = desiredVelocity - owner.getVelocity();
                return steering;
            }

            return -owner.getVelocity();
        }
    }
}