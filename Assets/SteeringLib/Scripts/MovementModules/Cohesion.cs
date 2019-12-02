using UnityEngine;
using System.Collections.Generic;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {
        [Header("Cohesion")]
        public float maxCohesion = 10f;
        
        private Vector3 stepCohesion(IList<IAgent> agents)
        {
            var centerOfMass = owner.getPosition();
            var neighboursAmount = 1;

            for (var i = 0; i < agents.Count; i++)
            {
                var a = agents[i];
                if (a != owner)
                {
                    var distance = Vector3.Distance(owner.getPosition(), a.getPosition());
                    if (distance < maxCohesion)
                    {
                        centerOfMass += a.getPosition();
                        neighboursAmount++;
                    }
                }
            }

            if (neighboursAmount > 1)
            {
                centerOfMass /= neighboursAmount;

                return stepSeek(centerOfMass);
            }

            return Vector3.zero;
        }
    }
}