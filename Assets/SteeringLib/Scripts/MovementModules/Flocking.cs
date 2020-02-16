using UnityEngine;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {
        private Vector3 stepFlocking()
        {
            var target = steeringOwner.getTarget();
            if (owner.hasGroup())
            {
                var agents = owner.getGroup().getMembers();

                var steering = stepArrival(target.getPosition());
                steering += stepSeparation();
                steering += stepCohesion(agents) * 0.2f;
                steering += stepAlignment(agents);

                return steering;
            }
            return Vector3.zero;
        }
    }
}