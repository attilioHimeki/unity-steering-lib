using UnityEngine;

namespace UnitySteeringLib
{
    public class Evade : Pursue
    {
        public Evade(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            return -base.step();
        }
    }
}