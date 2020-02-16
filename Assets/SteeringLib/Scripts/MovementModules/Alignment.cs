using UnityEngine;
using System.Collections.Generic;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {
        private Vector3 stepAlignment(IList<IAgent> agents)
        {
            var heading = Vector3.zero;
            var neighboursAmount = 0;

            for (var i = 0; i < agents.Count; i++)
            {
                var a = agents[i];
                if (a != owner)
                {
                    var distance = Vector3.Distance(owner.getPosition(), a.getPosition());
                    if (distance < maxCohesion && a.getVelocity().magnitude > 0)
                    {
                        heading += a.getVelocity().normalized;
                        neighboursAmount++;
                    }
                }
            }

            if (neighboursAmount > 0)
            {
                heading /= neighboursAmount;

                var desired = heading * owner.getMaxSpeed();
                var steering = desired - velocity;
                return steering * (owner.getMaxForce() / owner.getMaxSpeed());
            }

            return Vector3.zero;
        }
    }

}