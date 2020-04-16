using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Evade : Pursue
    {
        public float safeDistance = 10f;
        public Evade(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            Vector3 distanceVector = owner.target.getPosition() - owner.getPosition();
            float distance = distanceVector.magnitude;

            if (distance < safeDistance)
            {
                return -base.step();
            }
            else
            {
                return -owner.getVelocity();
            }
        }
    }
}