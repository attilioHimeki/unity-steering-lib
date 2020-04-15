using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Pursue : SteeringBehaviour
    {
        public Pursue(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            var target = owner.target;
            var distanceVector = target.getPosition() - owner.getPosition();
            float distance = distanceVector.magnitude;

            var relativeHeading = Vector3.Dot(owner.getVelocity().normalized, target.getVelocity().normalized);
            //Todo: Handle case where target and agent are facing each other

            var anticipationMultiplier = distance / owner.getMaxSpeed();
            var pursueTargetPos = target.getPosition() + target.getVelocity() * anticipationMultiplier;
            
            var pursueTargetDistanceVector = pursueTargetPos - owner.getPosition();
            var desiredVelocity = pursueTargetDistanceVector.normalized * owner.getMaxSpeed();

            var steering = desiredVelocity - owner.getVelocity();

            return steering;
        }

    }
}