using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Seek : SteeringBehaviour
    {
        public Seek(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            var desiredVelocity = owner.target.getPosition() - owner.getPosition();
            desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed();

            var steering = desiredVelocity - owner.getVelocity();

            return steering;
        }
    }

}