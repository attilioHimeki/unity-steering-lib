using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Pursue : SteeringBehaviour
    {
        public float anticipationFactor = 2f;

        public Pursue(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            IAgent target = owner.target;

            Vector3 pursueTargetPos = target.getPosition() + target.getVelocity() * anticipationFactor;

            Vector3 pursueTargetDistanceVector = pursueTargetPos - owner.getPosition();
            Vector3 desiredVelocity = pursueTargetDistanceVector.normalized * owner.getMaxSpeed();

            Vector3 steering = desiredVelocity - owner.getVelocity();

            return steering;
        }

    }
}