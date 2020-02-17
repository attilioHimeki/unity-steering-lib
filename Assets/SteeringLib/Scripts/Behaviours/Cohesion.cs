using UnityEngine;

namespace UnitySteeringLib
{
    public class Cohesion : SteeringBehaviour
    {
        public float maxCohesion = 10f;
        public Cohesion(SteeringAgent owner)
        : base(owner)
        {
        }

        public override Vector3 step()
        {
            var centerOfMass = owner.getPosition();
            var neighboursAmount = 1;

            var ownerGroup = owner.getGroup();
            if(ownerGroup != null)
            {
                var members = ownerGroup.getMembers();

                if(members.Count > 1)
                {
                    for (var i = 0; i < members.Count; i++)
                    {
                        var a = members[i];
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

                        var desiredVelocity = centerOfMass - owner.getPosition();
                        desiredVelocity = desiredVelocity.normalized * owner.getMaxSpeed();

                        var steering = desiredVelocity - owner.getVelocity();

                        return steering;
                    }
                }
            }

            return Vector3.zero;
        }
    }
}