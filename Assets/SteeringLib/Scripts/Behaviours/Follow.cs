using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Follow : SteeringBehaviour
    {
        public float followDistance = 3f;

        public Follow(SteeringAgent owner)
        : base(owner)
        {
        }
        
        public override Vector3 step()
        {
            Vector3 offset = -owner.target.getForward() * followDistance;
            Vector3 targetFollowPos = owner.target.getPosition() + offset;
            Vector3 targetFollowPosDistance = targetFollowPos - owner.getPosition();

            if(targetFollowPosDistance.sqrMagnitude > Mathf.Epsilon)
            {
                Vector3 desiredVelocity = targetFollowPosDistance.normalized * owner.getMaxSpeed();
                Vector3 steering = desiredVelocity - owner.getVelocity();
                return steering;
            }

            return -owner.getVelocity();
        }
    }
}