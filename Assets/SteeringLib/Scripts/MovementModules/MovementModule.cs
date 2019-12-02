using UnityEngine;

namespace UnitySteeringLib
{
    public class MovementModule
    {
        public IAgent owner { get; protected set; }
        public Vector3 velocity;
        public AgentsGroup group { get; protected set; }

        public MovementModule(IAgent agent)
        {
            owner = agent;
        }

        public virtual Vector3 getStep(float dt)
        {
            return Vector3.zero;
        }

    }
}
