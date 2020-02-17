using UnityEngine;

namespace UnitySteeringLib
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

            var relativeHeading = Vector3.Dot(owner.getVelocity().normalized, target.getVelocity().normalized);
            //Todo: Handle case where target and agent are facing each other

            var anticipationMultiplier = distanceVector.magnitude / owner.getMaxSpeed();
            var pursueTargetPos = target.getPosition() + target.getVelocity() * anticipationMultiplier;
            
            var desiredVelocity = pursueTargetPos - owner.getPosition();
            desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed();

            var steering = desiredVelocity - owner.getVelocity();

            return steering;
        }

    }
}