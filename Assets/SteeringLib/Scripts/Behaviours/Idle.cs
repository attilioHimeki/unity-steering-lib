using UnityEngine;

namespace Himeki.AI.Steering
{
    public class Idle : SteeringBehaviour
    {
        public Idle(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            return Vector3.zero;
        }
    }
}