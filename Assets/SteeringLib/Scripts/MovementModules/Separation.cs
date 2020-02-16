using UnityEngine;
using System.Collections.Generic;

namespace UnitySteeringLib
{
    public partial class SteeringMovementModule : MovementModule
    {
        [Header("Separation")]
        public float minSeparationDistance = 3f;

        public Vector3 stepSeparation()
        {
            var totalForce = Vector3.zero;
            var neighboursAmount = 0;

            var ownerGroup = owner.getGroup();
            if(ownerGroup != null)
            {
                var members = ownerGroup.getMembers();

                for (var i = 0; i < members.Count; i++)
                {
                    var a = members[i];
                    if (a != owner)
                    {
                        var distance = Vector3.Distance(owner.getPosition(), a.getPosition());
                        if (distance < minSeparationDistance && distance > 0f)
                        {
                            var pushForce = owner.getPosition() - a.getPosition();
                            totalForce += pushForce / a.getRadius();
                            neighboursAmount++;
                        }
                    }
                }

                if (neighboursAmount > 0)
                {
                    totalForce /= neighboursAmount;
                    return totalForce * owner.getMaxForce();
                }
            }

            return Vector3.zero;
        }
    }
}